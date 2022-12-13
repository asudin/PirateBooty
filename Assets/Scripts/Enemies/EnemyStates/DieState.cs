public class DieState : State
{
    private void Start()
    {
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
