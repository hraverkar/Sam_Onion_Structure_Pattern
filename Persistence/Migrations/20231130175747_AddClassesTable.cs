using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddClassesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.InsertData(
            table: "Classes",
            columns: new[] { "Id", "ClassName", "Section", "CreatedAt", "CreatedBy", "UpdatedAt" },
            values: new object[,]
            {
                    { Guid.NewGuid(), "1st Class", "A", DateTime.Now, "Harshal Raverkar", DateTime.Now },
                    { Guid.NewGuid(), "1st Class", "B", DateTime.Now, "Harshal Raverkar", DateTime.Now, },
                    { Guid.NewGuid(), "1st Class", "C", DateTime.Now, "Harshal Raverkar", DateTime.Now, },
                    { Guid.NewGuid(), "1st Class", "D", DateTime.Now, "Harshal Raverkar", DateTime.Now, },

                    { Guid.NewGuid(), "2nd Class", "A", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "2nd Class", "B", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "2nd Class", "C", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "2nd Class", "D", DateTime.Now, "Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "3rd Class", "A", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "3rd Class", "B", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "3rd Class", "C", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "3rd Class", "D", DateTime.Now, "Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "4th Class", "A", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "4th Class", "B", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "4th Class", "C", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "4th Class", "D", DateTime.Now, "Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "5th Class", "A",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "5th Class", "B",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "5th Class", "C",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "5th Class", "D",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "6th Class", "A",  DateTime.Now,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "6th Class", "B",  DateTime.Now, "Harshal Raverkar", DateTime.Now},
                    { Guid.NewGuid(), "6th Class", "C",  DateTime.Now, "Harshal Raverkar", DateTime.Now},
                    { Guid.NewGuid(), "6th Class", "D",  DateTime.Now, "Harshal Raverkar", DateTime.Now},

                    { Guid.NewGuid(), "7th Class", "A", DateTime.Now,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "7th Class", "B", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "7th Class", "C", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "7th Class", "D", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "8th Class", "A", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "8th Class", "B", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "8th Class", "C", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "8th Class", "D", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "9th Class", "A", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "9th Class", "B", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "9th Class", "C", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "9th Class", "D", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "10th Class", "A", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "10th Class", "B", DateTime.Now ,"Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "10th Class", "C", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "10th Class", "D", DateTime.Now, "Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "11th Class", "Mathematics", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "11th Class", "Biology",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "11th Class", "Commerce ", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "11th Class", "Arts",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},

                    { Guid.NewGuid(), "12th Class", "Mathematics",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "12th Class", "Biology",  DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "12th Class", "Commerce", DateTime.Now, "Harshal Raverkar" , DateTime.Now},
                    { Guid.NewGuid(), "12th Class", "Arts", DateTime.Now, "Harshal Raverkar", DateTime.Now }
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
