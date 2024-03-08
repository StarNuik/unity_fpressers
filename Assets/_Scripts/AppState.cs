public class AppState
{
	public bool SuppressPlayer { get; set; } = false;
	public Cutscene PendingInteraction { get; set; }

	public float ScreenEmission { get; set; } = 0f;
	public bool ShaderSauceIsTimelined = false;
}