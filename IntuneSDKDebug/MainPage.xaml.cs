using Microsoft.Intune.MAM;

namespace IntuneSDKDebug;

public partial class MainPage : ContentPage
{	

	public MainPage()
	{
		InitializeComponent();
	}

	// Open Intune Diagnostic Console
	private async void OpenIntuneDiagnosticClicked(object sender, EventArgs e)
	{
		try
		{
			// this does NOT work on an .net8 Maui Release Binary (!)
			IntuneMAMDiagnosticConsole.DisplayDiagnosticConsole();
		}
		catch (Exception ex)
		{
            await DisplayAlert("Error", ex.Message, "OK");
		}
    }

    // Get Intune Logs and show it via DisplayAlert
    private async void ShowIntuneDiagnosticLogs(object sender, EventArgs e)
    {
        try
        {
            // this works on Release AND Debug Binary as expected
            var logs = IntuneMAMDiagnosticConsole.DiagnosticInformation;

			await DisplayAlert("Intune Logs", logs.ToString(),"OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}


