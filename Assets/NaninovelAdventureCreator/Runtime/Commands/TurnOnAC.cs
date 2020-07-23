using AC;
using Naninovel.Commands;
using UniRx.Async;

namespace Naninovel.AC
{
    /// <summary>
    /// Enables Adventure Creator and (optionally) resets Naninovel engine.
    /// </summary>
    public class TurnOnAC : Command
    {
        /// <summary>
        /// Whether to reset the state and stop all the Naninovel engine services.
        /// </summary>
        public BooleanParameter Reset = true;
        /// <summary>
        /// Whether to disable Naninovel's camera and enable Adventure Creator's main camera.
        /// </summary>
        public BooleanParameter SwapCameras = true;

        public override async UniTask ExecuteAsync (CancellationToken cancellationToken = default)
        {
            if (Reset) await Engine.GetService<StateManager>().ResetStateAsync();

            KickStarter.TurnOnAC();

            if (SwapCameras)
            {
                KickStarter.mainCamera.enabled = true;
                Engine.GetService<CameraManager>().Camera.enabled = false;
            }
        }
    }
}
