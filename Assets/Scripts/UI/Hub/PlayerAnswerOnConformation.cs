public class PlayerAnswerOnConformation {

    private string answer;
    private ShopManager shopManager;

    private PlayerAnswerOnConformation() { }
    public PlayerAnswerOnConformation(
        string answer, ShopManager shopManager)
    {
        this.answer = answer;
        this.shopManager = shopManager;
        Answer(answer);
    }
    public void Answer(string answer)
    {
        if (answer == "Yes")
        {
            if (shopManager.Buying)
            {
                shopManager.ExecuteTransaction();
                shopManager.confirmPurches.SetActive(
                    !shopManager.confirmPurches.activeSelf);
            }
            else
            {
                shopManager.ExecuteTransaction();
                shopManager.confirmPurches.SetActive(
                    !shopManager.confirmPurches.activeSelf);
            }
        }
        else
        {
            shopManager.confirmPurches.SetActive(
                !shopManager.confirmPurches.activeSelf);
        }
    }

}
