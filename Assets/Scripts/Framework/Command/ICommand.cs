namespace Asteroids.Framework.Command {
    // todo-naming:
    // - Command: it is not a command in its original form
    // - Signal: the signal only notifies about something, but does not do the operation.
    // - Action: too generic, but it's close in meaning
    // - Operation/Process: too veiled
    // - Message: too generic
    // - Event: conflict with c# events, but it's close in meaning
    public interface ICommand { }
}