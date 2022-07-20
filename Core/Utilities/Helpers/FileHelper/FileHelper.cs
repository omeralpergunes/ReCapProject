﻿using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            var result = CheckIfFileExists(filePath);
            if (!result.Success)
            {
                return result;
            }
            File.Delete(filePath);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            var resultOfDelete = Delete(filePath);
            if (!resultOfDelete.Success)
            {
                return resultOfDelete;
            }

            var resultOfUpload = Upload(file, root);
            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            return new SuccessResult(resultOfUpload.Message);
        }

        public IResult Upload(IFormFile file, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(file),
                CheckIfFileExtensionValid(Path.GetExtension(file.FileName)));

            if (result != null)
            {
                return result;
            }

            string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);

            CheckIfDirectoryExists(root);

            CreateFile(root + fileName, file);

            return new SuccessResult(fileName);
        }


        //Business Rules
        private IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya bulunamadı");
        }

        private IResult CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
            {
                return new ErrorResult("Dosya girilmedi.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfFileExtensionValid(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Girmiş olduğunuz dosya uzantısı geçerli değildir");
        }

        private void CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream); 
                fileStream.Flush(); 
            }
        }


    }
}