namespace DTO;
public class StoreDTO
{
    public string name;
    public string CNPJ;
    public List<PurchaseDTO> purchase=new List<PurchaseDTO>();
    public OwnerDTO owner;
}
