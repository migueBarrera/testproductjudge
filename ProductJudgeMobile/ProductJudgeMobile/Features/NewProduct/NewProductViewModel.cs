using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudgeMobile.Features.ProductDetail;
using System.Collections.ObjectModel;

namespace ProductJudgeMobile.Features.NewProduct;

public partial class NewProductViewModel : ObservableObject
{
    // Propiedades del producto
    [ObservableProperty]
    private string productName;

    [ObservableProperty]
    private string productDescription;

    [ObservableProperty]
    private string productImage;

    [ObservableProperty]
    private decimal productPrice;

    public NewProductViewModel()
    {
        // Constructor vacío o lógica de inicialización si es necesario
    }

    // Comando para crear el producto
    [RelayCommand]
    private async Task CreateProduct()
    {
        // Validación de los campos
        if (string.IsNullOrWhiteSpace(ProductName) ||
            string.IsNullOrWhiteSpace(ProductDescription) ||
            string.IsNullOrWhiteSpace(ProductImage) ||
            ProductPrice <= 0)
        {
            // Mostrar algún mensaje de error al usuario (si hay algún servicio de mensajes implementado)
            await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios y el precio debe ser mayor a cero.", "OK");
            return;
        }

        // Lógica para crear el nuevo producto (puedes enviar los datos a una API, almacenarlos localmente, etc.)
        // Aquí simulo el envío del producto a una API o servicio
        await Task.Delay(1000); // Simulación de un tiempo de espera para la creación del producto

        // Mostrar mensaje de éxito
        await Application.Current.MainPage.DisplayAlert("Éxito", "El producto ha sido creado exitosamente.", "OK");

        // Limpiar los campos después de crear el producto
        ProductName = string.Empty;
        ProductDescription = string.Empty;
        ProductImage = string.Empty;
        ProductPrice = 0;
    }



}
