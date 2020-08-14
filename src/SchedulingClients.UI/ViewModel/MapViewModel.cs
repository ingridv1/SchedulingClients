using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GAAPICommon.Architecture;
using GACore;
using GACore.Command;
using GACore.UI.ViewModel;
using SchedulingClients.Core;
using SchedulingClients.Core.MapServiceReference;

namespace SchedulingClients.UI.ViewModel
{
    public class MapViewModel : AbstractViewModel<IMapClient>
    {
        internal MapViewModel()
        {
            HandleLoadCommands();
        }

        public ICommand MapOptionCommand { get; set; }

        private void HandleLoadCommands()
        {
            MapOptionCommand = new CustomCommand(MapOptionClick, CanMapOptionClick);
        }

        private void HandleGetMoves()
        {
            IServiceCallResult<MoveDto[]> result = Model.GetAllMoveData();

            if (result.IsSuccessful())
            {
                string filePath = result.Value.ToCSVFile();
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void HandleGetNodes()
        {
            IServiceCallResult<NodeDto[]> result = Model.GetAllNodeData();

            if (result.IsSuccessful())
            {
                string filePath = result.Value.ToCSVFile();
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void HandleOption(MapOption mapOption)
        {
            switch(mapOption)
            {
                case MapOption.GetMoves:
                    {
                        HandleGetMoves();
                        break;
                    }

                case MapOption.GetNodes:
                    {
                        HandleGetNodes();
                        break;
                    }

                default:
                    throw new NotImplementedException();
            }
        }


        private bool CanMapOptionClick(object obj) => true;

        private void MapOptionClick(object obj)
        {
            try
            {
                HandleOption((MapOption)obj);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
