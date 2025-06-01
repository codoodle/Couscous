using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Couscous.Messages
{
    public class SettingsChangedMessage([CallerMemberName] string? propertyName = null) : ValueChangedMessage<string?>(propertyName)
    {
    }
}