namespace Assets.HealthBarPractice.Codebase.Common.HealthBehavior.View.Interface
{
    public interface IHealthView
    {
        public void Init(int current, int max);
        public void UpdateView(int current, int max);
    }
}
