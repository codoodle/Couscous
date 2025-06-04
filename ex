using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class YamlMerger
{
    private readonly List<string> _ignorePaths;

    private readonly IDeserializer _deserializer;
    private readonly ISerializer _serializer;

    public YamlMerger(List<string> ignorePaths = null)
    {
        _ignorePaths = ignorePaths ?? new List<string>();

        _deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        _serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
    }

    public Dictionary<string, object> Merge(string yaml1, string yaml2)
    {
        var dict1 = _deserializer.Deserialize<Dictionary<string, object>>(yaml1);
        var dict2 = _deserializer.Deserialize<Dictionary<string, object>>(yaml2);

        return DeepMerge(dict1, dict2, "");
    }

    public string MergeToYaml(string yaml1, string yaml2)
    {
        var merged = Merge(yaml1, yaml2);
        return _serializer.Serialize(merged);
    }

    private Dictionary<string, object> DeepMerge(Dictionary<string, object> baseDict, Dictionary<string, object> overrideDict, string pathPrefix)
    {
        foreach (var kvp in overrideDict)
        {
            var key = kvp.Key;
            var overrideValue = kvp.Value;
            var fullPath = string.IsNullOrEmpty(pathPrefix) ? key : $"{pathPrefix}.{key}";

            if (_ignorePaths.Contains(fullPath))
                continue;

            if (baseDict.TryGetValue(key, out var baseValue))
            {
                if (baseValue is Dictionary<object, object> baseSubDict &&
                    overrideValue is Dictionary<object, object> overrideSubDict)
                {
                    baseDict[key] = DeepMerge(
                        ConvertToStringKeyDict(baseSubDict),
                        ConvertToStringKeyDict(overrideSubDict),
                        fullPath
                    );
                }
                else if (baseValue is IList baseList && overrideValue is IList overrideList)
                {
                    baseDict[key] = MergeLists(baseList, overrideList);
                }
                else
                {
                    baseDict[key] = overrideValue;
                }
            }
            else
            {
                baseDict[key] = overrideValue;
            }
        }

        return baseDict;
    }

    private static List<object> MergeLists(IList list1, IList list2)
    {
        var merged = new List<object>(list1.Cast<object>());

        foreach (var item in list2)
        {
            if (!merged.Contains(item)) // 중복 제거
                merged.Add(item);
        }

        return merged;
    }

    private static Dictionary<string, object> ConvertToStringKeyDict(Dictionary<object, object> dict)
    {
        var result = new Dictionary<string, object>();
        foreach (var kvp in dict)
        {
            var key = kvp.Key.ToString() ?? "";
            if (kvp.Value is Dictionary<object, object> subDict)
            {
                result[key] = ConvertToStringKeyDict(subDict);
            }
            else if (kvp.Value is IList list)
            {
                result[key] = list.Cast<object>().ToList();
            }
            else
            {
                result[key] = kvp.Value;
            }
        }
        return result;
    }
}