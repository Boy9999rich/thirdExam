using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFileManagement.Service.Service;
using WebFileManagerment.StorageBroker.Services;

namespace G10ThirdModulExam.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("UploadFile")]
        public async Task UploadFile(IFormFile file, string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            filePath = Path.Combine(filePath, file.FileName);
            using(var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
               using(var destinationFile = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    
                }
            }
        }
        [HttpPost("UploadFiles")]
        public async Task UploadFiles(List<IFormFile> files, string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            if (!Directory.Exists(filePath))
            {
                throw new Exception("not found FilePath");
            }

            foreach (var file in files)
            {
                filePath = Path.Combine(filePath, file.FileName);
                var res = new FileStream(filePath, FileMode.Open, FileAccess.Read)
                {
                    
                };
            }
        }
        [HttpGet("GetAllFiles")]
        public async Task<List<string>> GetAllFilesAndDirectories(string ? folderPath)
        {
            folderPath = folderPath ?? string.Empty;
            return await  _storageService.GetAllInFolderPathAsync(folderPath);
        }

        [HttpGet("UploadFilesWithChunksAsync")]
        public async Task UploadFilesWithChunksAsync(string filePath, string newFile)
        {
            await _storageService.UploadFilesWithChunksAsync(filePath, newFile);
        }
        [HttpGet("DownloadFile")]
        public async Task<Stream> DownloadFile(string filePath)
        {
            return await _storageService.DownloadFileAsync(filePath);
            
        }

        [HttpGet("DownloadFolderAsZip")]
        public async Task<Stream> DownloadFolderAsZip(string folderPath)
        {
            return await _storageService.DownloadFolderAsZipAsync(folderPath);

        }

        [HttpGet("DeleteFile")]
        public async Task DeleteFile(string filePath)
        {
             await _storageService.DownloadFolderAsZipAsync(filePath);

        }

        [HttpGet("DeleteFolder")]
        public async Task DeleteFolder(string folderPath)
        {
            await _storageService.DeleteFolderAsync(folderPath);

        }
    }
}
