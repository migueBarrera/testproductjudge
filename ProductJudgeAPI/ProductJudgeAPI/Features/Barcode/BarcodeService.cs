using Microsoft.Extensions.Options;
using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Helpers;

namespace ProductJudgeAPI.Features.Barcode;

public class BarcodeService : MongoServiceBase<Entities.Barcode>
{
    public BarcodeService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings) : base(bookStoreDatabaseSettings)
    {
    }

    public override string CollectionName()
    {
        return bookStoreDatabaseSettings.Value.BarcodeCollectionName;
    }
}
