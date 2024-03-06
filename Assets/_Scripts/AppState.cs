public class AppState
{
	public bool SuppressPlayer { get; set; } = false;
	public float MilkStrength { get; set; } = 0f;
	public float FogMilkRatio { get; set; } = 0f;
	public float ScreenEmission { get; set; } = 0f;
	public Cutscene PendingInteraction { get; set; }
}