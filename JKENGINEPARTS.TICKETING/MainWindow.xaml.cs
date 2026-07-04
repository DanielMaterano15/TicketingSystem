using System.Windows;
using System.Windows.Controls;
using JKENGINEPARTS.TICKETING.Models;

namespace JKENGINEPARTS.TICKETING
{
    public partial class MainWindow : Window
    {
        private List<Ticket> _ticketsSimulados;

        public MainWindow()
        {
            InitializeComponent();
            CargarTicketsDePrueba();

            dgTickets.SelectionChanged += DgTickets_SelectionChanged;

            btnGuardarCotizacion.Click += BtnGuardarCotizacion_Click;
            btnCopiarVenta.Click += BtnCopiarVenta_Click;
        }

        private void CargarTicketsDePrueba()
        {
            _ticketsSimulados = new List<Ticket>
            {
                new Ticket
                {
                    TallerNombre = "Master Autotech",
                    VehiculoInfo = "Toyota Corolla 2012 Motor 1.8",
                    Status = TicketStatus.Pendiente,
                    Items = new List<TicketItem>
                    {
                        new TicketItem { ID = 1, RepuestoSolicitado = "Bomba de agua" },
                        new TicketItem { ID = 2, RepuestoSolicitado = "Pastillas de freno delanteras" }
                    }
                },
                new Ticket
                {
                    TallerNombre = "QuikService Elite",
                    VehiculoInfo = "Toyota corolla cross 2025 motor 2.0",
                    Status = TicketStatus.Pendiente,
                    Items = new List<TicketItem>
                    {
                        new TicketItem { ID = 3, RepuestoSolicitado = "Kit de tiempo" },
                        new TicketItem { ID = 4, RepuestoSolicitado = "Empacadura de Cámara" }
                    }
                }
            };

            dgTickets.ItemsSource = _ticketsSimulados;
        }

        private void DgTickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTickets.SelectedItem is Ticket ticketSeleccionado)
            {
                lblVehiculo.Text = $"Vehiculo: {ticketSeleccionado.VehiculoInfo} ({ticketSeleccionado.TallerNombre})";

                dgItemsCotizacion.ItemsSource = ticketSeleccionado.Items;

                dgItemsCotizacion.Items.Refresh();
            }
        }

        private void BtnGuardarCotizacion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cotización Guardada localmente. Aquí enviarías los datos actualizados a la base de datos. ", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private void BtnCopiarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (dgTickets.SelectedItem is Ticket ticketSeleccionado)
            {
                string mensajeVenta = "";
                foreach (var item in ticketSeleccionado.Items)
                {
                    mensajeVenta +=
                        $"VENTA [{ticketSeleccionado.VehiculoInfo}] \"{item.DescripcionOfrecida}\" \"{item.Marca}\" \"${item.PrecioMayor}\"\n";
                }
                
                Clipboard.SetText(mensajeVenta);
                MessageBox.Show("Texto de VENTA copiado al portapapeles!", "Portapapeles", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }
    }
}