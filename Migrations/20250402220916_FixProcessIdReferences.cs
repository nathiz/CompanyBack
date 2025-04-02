using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyBack.Migrations
{
    /// <inheritdoc />
    public partial class FixProcessIdReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subprocessos_Processos_ProcessId",
                table: "Subprocessos");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "Subprocessos",
                newName: "ProcessoId");

            migrationBuilder.RenameIndex(
                name: "IX_Subprocessos_ProcessId",
                table: "Subprocessos",
                newName: "IX_Subprocessos_ProcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subprocessos_Processos_ProcessoId",
                table: "Subprocessos",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subprocessos_Processos_ProcessoId",
                table: "Subprocessos");

            migrationBuilder.RenameColumn(
                name: "ProcessoId",
                table: "Subprocessos",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Subprocessos_ProcessoId",
                table: "Subprocessos",
                newName: "IX_Subprocessos_ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subprocessos_Processos_ProcessId",
                table: "Subprocessos",
                column: "ProcessId",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
