namespace eShop.UseCases.AdminPortal.ProcessedOrder
{
    public interface IProcessedOrderUseCase
    {
        bool ExecuteProcessedOrder(int orderid, string adminUserName);
    }
}