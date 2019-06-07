// Este ejemplo viene de https://geeks.ms/rjimenez/2010/06/29/generando-bsquedas-mediante-el-patrn-especificacin/
public class BankAccountSearchSpecification : Specification<BankAccount>
{
	public BankAccountSearchValues SearchValues { get; set; }
			
	public BankAccountSearchSpecification(BankAccountSearchValues searchValues)
	{ 
		SearchValues=searchValues;
	}

	public override Expression<Func<BankAccount, bool>> SatisfiedBy()
	{
		Specification<BankAccount> spec = new TrueSpecification<BankAccount>();
		if(SearchValues.CustomerName != string.Empty)
		{
			spec &= new DirectSpecification<BankAccount>(element => element.CustomerName == (SearchValues.CustomerName));
		}
		if(SearchValues.BankAccountNumber != string.Empty)
		{
			spec &= new DirectSpecification<BankAccount>(element => element.BankAccountNumber == (SearchValues.BankAccountNumber));
		}
		if (SearchValues.NotInSearch != null)
		{
		    spec &= new NotSpecification<BankAccount>(new BankAccountSearchSpecification(SearchValues.NotInSearch));
		}  

		return spec.SatisfiedBy();
	}
}

public class BankAccountSearchValues
{	
	public string CustomerName { get; set;	}
	public string BankAccountNumber	{ get; set; }
	public BankAccountSearchValues NotInSearch { get; set; }
}