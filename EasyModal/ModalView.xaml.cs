using System.Windows.Controls;
using System.Windows.Input;

namespace EasyModal;

public partial class ModalView : UserControl
{
    private EasyModal.ModalViewModel Vm => (EasyModal.ModalViewModel)DataContext;

    public ModalView() => InitializeComponent();

    private void CloseModal(object sender, MouseButtonEventArgs e) => Vm.Close();
}