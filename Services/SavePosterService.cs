using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHorder.Services
{
    class SavePosterService : ISavePosterService
    {
        public async Task SavePosterAsync(string imageUrl, string fileName)
        {
            try
            {
                // Download the image
                using var httpClient = new HttpClient();
                var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                // Determine the save location
                string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                // Save the image to local storage
                File.WriteAllBytes(filePath, imageBytes);

                await Application.Current.MainPage.DisplayAlert("Success", "Poster saved to collection!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Sorry!", $"Failed to save poster: {ex.Message}", "OK");
            }
        }

    }
}
