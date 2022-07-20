using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;


namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        IResult Delete(string filePath);
        IResult Upload(IFormFile file, string root);
        IResult Update(IFormFile file, string filePath, string root);

    }
}
