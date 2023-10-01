using cesapp.Context;
using cesapp.Models;
using OfficeOpenXml;

namespace cesapp.Services
{
	public interface IExcelFileHandler
	{
		int fileValidation(ExcelWorksheet worksheet);
		void insertInDatabase(ExcelWorksheet worksheet);
	}
	public class ExcelFileHandler : IExcelFileHandler
	{
		private readonly IDateValidation _dateValidation;
		private readonly ApplicationDbContext _context;
        public ExcelFileHandler(IDateValidation dateValidation, ApplicationDbContext context)
        {
            _dateValidation = dateValidation;
			_context = context;
        }
        public int fileValidation(ExcelWorksheet worksheet)
		{
			int rows = worksheet.Dimension.Rows;
			int columns = worksheet.Dimension.Columns;
			for (int row = 2; row < rows; row++)
			{
				for (int col = 1; col < columns; col++)
				{
					var cellValue = worksheet.Cells[row, col].Value;
					if (cellValue != null)
					{
						if (col == 5 && _dateValidation.IsValidDateFormat(cellValue.ToString()) == false)
						{
							return row - 1;
						}
					}
				}
			}
			return 0;
		}
		public void insertInDatabase(ExcelWorksheet worksheet)
		{
			int rows = worksheet.Dimension.Rows;
			int columns = worksheet.Dimension.Columns;
            Machine newMachine = new Machine();
			for (int row = 2; row < rows; row++)
			{
				for (int col = 1; col < columns; col++)
				{
					var cellValue = worksheet.Cells[row, col].Value;
					if (cellValue != null)
					{
						switch(col)
						{
							case 2:
								var typeMachine = cellValue.ToString();
								var returnedTypeMachine = _context.MachineTypes.FirstOrDefault(M => M.MachineTypeName.Equals(typeMachine));
								if(returnedTypeMachine != null)
								{
									newMachine.MachineTypeId = returnedTypeMachine.MachineTypeId;
								}
								else
								{
									MachineType machineType = new MachineType()
									{
										MachineTypeName = typeMachine
									};
									_context.MachineTypes.Add(machineType);
									_context.SaveChanges();
									var maxId = _context.MachineTypes.Max(M => M.MachineTypeId);
									newMachine.MachineTypeId = maxId;
								}
								break;
							case 3:
								var fournisseur = cellValue.ToString();
								var returnedFournisseur = _context.Fournisseurs.FirstOrDefault(F => F.FournisseurName.Equals(fournisseur));
								if (returnedFournisseur != null)
								{
									newMachine.FournisseurId = returnedFournisseur.FournisseurId;
								}
								else
								{
									Fournisseur newFournisseur = new Fournisseur()
									{
										FournisseurName = fournisseur
									};
									_context.Fournisseurs.Add(newFournisseur);
									_context.SaveChanges();
									var maxId = _context.Fournisseurs.Max(F => F.FournisseurId);
									newMachine.FournisseurId = maxId;
								}
								break;
						}
						newMachine.OperateurId = 1;
						if(col == 4)
						{
							newMachine.Nfacture = cellValue.ToString();
						}
						if (col == 1)
						{
							newMachine.Designation = cellValue.ToString();
						}
						if (col == 5)
						{
							newMachine.DateAcquisition = DateTime.Parse(cellValue.ToString());
						}
						Console.WriteLine("facteur "+newMachine.Nfacture);
						Console.WriteLine("operateurid "+newMachine.OperateurId);
						Console.WriteLine("machinetype "+newMachine.MachineId);
						Console.WriteLine("date "+newMachine.DateAcquisition);
						Console.WriteLine("designation "+newMachine.Designation);
						Console.WriteLine("fournisseur "+newMachine.FournisseurId);
						Console.WriteLine("===============");
						//_context.Machines.Add(newMachine);
						//_context.SaveChanges();
					}
				}
			}

		}
	}
}
