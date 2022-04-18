namespace DTO;
public class StoreDTO
{
    public string Name;
    public string CNPJ;
    public List<PurchaseDTO> purchase=new List<PurchaseDTO>();
    public OwnerDTO owner;
}
