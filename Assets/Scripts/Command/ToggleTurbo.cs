namespace Chapter.Command
{
    public class ToggleTurbo : Command
    {
        PlayerController controller;

        public ToggleTurbo(PlayerController playerController)
        {
            controller = playerController;
        }

        public override void Execute()
        {
            controller.ToggleTurbo();
        }
    }
}