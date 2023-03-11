namespace Domain.Company.Abstract;

public interface IMoneyWithdraw
{
    bool WithdrawMoney(CompanyProject project, double money);
}
