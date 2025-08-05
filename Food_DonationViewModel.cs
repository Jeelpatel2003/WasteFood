public class Food_DonationViewModel
{
    public int DonationId { get; set; }
    public int D_Id { get; set; }
    public string Food_Name { get; set; } = string.Empty; // Fix: Initialize with a default value  
    public string Food_Description { get; set; } = string.Empty; // Fix: Initialize with a default value  
    public int Quantity { get; set; }
    public string PickupAddress { get; set; } = string.Empty; // Fix: Initialize with a default value  
    public string ContactNo { get; set; } = string.Empty; // Fix: Initialize with a default value  
    public string Status { get; set; } = string.Empty; // Fix: Initialize with a default value  

    // Fix: Declare the property as nullable to resolve CS8618
    public IFormFile? ImageFile { get; set; }

    public string ImagePath { get; set; } = string.Empty; // Fix: Initialize with a default value  
    public string ContactNumber { get; internal set; } = string.Empty; // Fix: Initialize with a default value  
}
