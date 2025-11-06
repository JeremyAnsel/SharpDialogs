namespace SharpDialogs;

#if !NETSTANDARD2_0
/// <summary>
/// A prompt in a dialog box.
/// </summary>
public static class SharpInputBox
{
    /// <summary>
    /// Displays a prompt in a dialog box, waits for the user to input text or click a button, and then returns a string containing the contents of the text box.
    /// </summary>
    /// <param name="prompt">The prompt of the dialog.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="defaultResponse">The default reponse of the dialog.</param>
    /// <param name="xPos">The x position of the dialog.</param>
    /// <param name="yPos">The y position of the dialog.</param>
    /// <returns></returns>
    public static string Show(string prompt, string title = "", string defaultResponse = "", int xPos = -1, int yPos = -1)
    {
        return Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultResponse, xPos, yPos);
    }
}
#endif
