namespace SuperZapatos.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class Articles
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Total_in_Shelf { get; set; }

        [Required]
        public decimal Total_in_Vault { get; set; }

        [Required]
        public long Store_Id { get; set; }

        public string StoreName { get; set; }


    }
}
