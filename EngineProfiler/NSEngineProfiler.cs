using Microsoft.Xna.Framework;

namespace NeverSurrender.EngineProfiler
{
    public sealed class NSEngineProfiler : GameComponent
    {
        #region CONSTRUCTOR(S)
        public NSEngineProfiler(Game game)
            : base(game)
        {

        }
        #endregion

        #region DELEGATE(S)
        #endregion

        #region EVENT(S)
        public event EngineRunningFast OnEngineRunningFast;
        public event EngineRunningSlow OnEngineRunningSlow;
        #endregion

        #region FIELD(S)
        double elapsedTime;
        double cycleCounter;

        double engineEfficiency;
        double cyclesPerSecond;
        double averageCyclesPerSecond;

        double targetCycleCount;
        #endregion

        #region METHOD(S)
        public override void Initialize()
        {
            base.Initialize();

            elapsedTime = 0;
            cycleCounter = 0;

            engineEfficiency = 1.0;
            cyclesPerSecond = 60.0;
            targetCycleCount = 60.0;
            averageCyclesPerSecond = 60.0;
            
        }
        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= 1.0)
            {
                cyclesPerSecond = cycleCounter / elapsedTime;
                averageCyclesPerSecond = (averageCyclesPerSecond + cyclesPerSecond) / 2.0;
                engineEfficiency = cyclesPerSecond / targetCycleCount;

                if (null != OnEngineRunningFast && engineEfficiency > 1.1)
                    OnEngineRunningFast(engineEfficiency);
                else if (null != OnEngineRunningSlow && engineEfficiency < .9)
                    OnEngineRunningSlow(engineEfficiency);

                cycleCounter = 0.0;
                elapsedTime -= 1.0;
            }

            base.Update(gameTime);

            cycleCounter++;
        }
        #endregion

        #region PROPERTY(IES)
        public double CyclesPerSecond { get { return cyclesPerSecond; } }
        public double EngineEfficiency { get { return engineEfficiency; } }
        #endregion
    }
}
