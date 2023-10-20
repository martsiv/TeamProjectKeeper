using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data_access.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Subcategories_SubcategoryId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "OrdersPositions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_Name",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_SubcategoryId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDishes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDishes", x => new { x.OrderId, x.DishId });
                    table.ForeignKey(
                        name: "FK_OrdersDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDishes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Кухня");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Бар");

            migrationBuilder.InsertData(
                table: "OrdersStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Відкрите" },
                    { 2, "Закрите без оплати" },
                    { 3, "Закрите та оплачене" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "PaymentType" },
                values: new object[,]
                {
                    { 1, "Готівка" },
                    { 2, "Картка" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Адміністратор" },
                    { 2, "Офіціант" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Гарніри" },
                    { 2, 1, "Гарячі закуски" },
                    { 3, 1, "Закуски" },
                    { 4, 1, "Перші страви" },
                    { 5, 1, "Салати" },
                    { 6, 1, "Риба та морепродукти" },
                    { 7, 1, "М'ясо & Птиця" },
                    { 8, 1, "Соуси" },
                    { 9, 1, "Десерти" },
                    { 10, 1, "Морозиво" },
                    { 11, 2, "Безалкогольні напої" },
                    { 12, 2, "Гарячі напої" },
                    { 13, 2, "Коктейлі алкогольні" },
                    { 14, 2, "Пиво" },
                    { 15, 2, "Вино" },
                    { 16, 2, "Горілка" },
                    { 17, 2, "Коньяк" },
                    { 18, 2, "Настоянки" },
                    { 19, 2, "Віскі" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, "Картопля по-селянськи", 65m, 1 },
                    { 2, "Картопля з сиром Чеддер", 69m, 1 },
                    { 3, "Картопляне пюре", 52m, 1 },
                    { 4, "Гречка з грибами", 56m, 1 },
                    { 5, "Картопля смажена", 68m, 1 },
                    { 6, "Локшина домашня", 52m, 1 },
                    { 7, "Тако", 129m, 2 },
                    { 8, "Самоса в лаваші", 127m, 2 },
                    { 9, "Сир по-чешськи", 103m, 2 },
                    { 10, "Дерун", 125m, 2 },
                    { 11, "Кров'янка з шукрутом", 117m, 2 },
                    { 12, "Ковбаски курячі", 139m, 2 },
                    { 13, "Ковбаски свинні", 144m, 2 },
                    { 14, "Ковбаски телячі", 148m, 2 },
                    { 15, "Асорті ковбас", 463m, 2 },
                    { 16, "Картопляні чіпси", 105m, 3 },
                    { 17, "Пивна тарілка", 103m, 3 },
                    { 18, "М'ясна тарілка до пива", 173m, 3 },
                    { 19, "Дошка з пивними закусками", 172m, 3 },
                    { 20, "Сирна тарілка", 316m, 3 },
                    { 21, "М'ясна тарілка", 172m, 3 },
                    { 22, "Дошка з копченостями", 215m, 3 },
                    { 23, "Рибна тарілка", 182m, 3 },
                    { 24, "Брускети з копченим сомом", 105m, 3 },
                    { 25, "Соління", 120m, 3 },
                    { 26, "Оселедець", 113m, 3 },
                    { 27, "Тартар з яловичини", 186m, 3 },
                    { 28, "Борщ український", 119m, 4 },
                    { 29, "Бульйон з телятини", 133m, 4 },
                    { 30, "Бограч", 119m, 4 },
                    { 31, "Грибна юшка", 105m, 4 },
                    { 32, "Грецький салат", 120m, 5 },
                    { 33, "Салат з копченим язиком", 174m, 5 },
                    { 34, "Теплий салат з телятини", 200m, 5 },
                    { 35, "Салат із печеним буряком", 93m, 5 },
                    { 36, "Салат зі свіжих овочів", 114m, 5 },
                    { 37, "Салат Цезар", 157m, 5 },
                    { 38, "Салат Оселедець під шубою", 92m, 5 },
                    { 39, "Салат з лососем", 226m, 5 },
                    { 40, "Салат Мімоза", 92m, 5 },
                    { 41, "Салат Олів'є", 119m, 5 },
                    { 42, "Креветки у сухарях панко", 238m, 6 }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price", "SubcategoryId" },
                values: new object[,]
                {
                    { 43, "Стейк з лосося", 442m, 6 },
                    { 44, "Мідії у вершковому соусі", 252m, 6 },
                    { 45, "Мойва в пивному клярі", 142m, 6 },
                    { 46, "Короп по-чеськи", 156m, 6 },
                    { 47, "Короп фрі", 76m, 6 },
                    { 48, "Копчена річкова форель", 100m, 6 },
                    { 49, "Курячі гомілки", 142m, 7 },
                    { 50, "Курячі крильця buffalo", 142m, 7 },
                    { 51, "Бургер яловичий з картоплею по-селянськи", 215m, 7 },
                    { 52, "Підкопчений язик", 221m, 7 },
                    { 53, "Куряче філе в беконі", 215m, 7 },
                    { 54, "Яловичий медальйон", 330m, 7 },
                    { 55, "Перепела", 214m, 7 },
                    { 56, "Качина ніжка конфі", 218m, 7 },
                    { 57, "Пів качки", 678m, 7 },
                    { 58, "Печінка теляча", 169m, 7 },
                    { 59, "Телячі щоки з хумусом", 175m, 7 },
                    { 60, "Волинський шніцель", 182m, 7 },
                    { 61, "Стейк свинний на кістці", 103m, 7 },
                    { 62, "Баварські реберця", 254m, 7 },
                    { 63, "Дошка з закусками", 787m, 7 },
                    { 64, "Рулька свинна", 409m, 7 },
                    { 65, "Трюфельний", 36m, 8 },
                    { 66, "Пікантний з каррі", 36m, 8 },
                    { 67, "Blue Cheese", 36m, 8 },
                    { 68, "BBQ", 30m, 8 },
                    { 69, "Тартар", 30m, 8 },
                    { 70, "Пілатті", 30m, 8 },
                    { 71, "Чізкейк", 112m, 9 },
                    { 72, "Яблучний штрудель", 89m, 9 },
                    { 73, "Creme Brulee", 78m, 9 },
                    { 74, "Бананове", 62m, 10 },
                    { 75, "Шоколадне", 62m, 10 },
                    { 76, "Пломбір", 50m, 10 },
                    { 77, "З джемами", 60m, 10 },
                    { 78, "Мохіто без алкогольне", 72m, 11 },
                    { 79, "Лимонад", 66m, 11 },
                    { 80, "Узвар", 80m, 11 },
                    { 81, "Боржомі", 66m, 11 },
                    { 82, "Моршинська", 33m, 11 },
                    { 83, "Pepsi", 47m, 11 },
                    { 84, "Сік", 36m, 11 }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price", "SubcategoryId" },
                values: new object[,]
                {
                    { 85, "Чай класичний", 55m, 12 },
                    { 86, "Чай фірмовий", 60m, 12 },
                    { 87, "Еспресо", 32m, 12 },
                    { 88, "Американо", 32m, 12 },
                    { 89, "Капучіно", 38m, 12 },
                    { 90, "Лате", 43m, 12 },
                    { 91, "Aperol Shpritz", 143m, 13 },
                    { 92, "Black Shpritz", 130m, 13 },
                    { 93, "Hugo", 142m, 13 },
                    { 94, "Bramble", 142m, 13 },
                    { 95, "Tommy's Margo", 162m, 13 },
                    { 96, "Amaro Sour", 162m, 13 },
                    { 97, "Бандерівський Mule", 130m, 13 },
                    { 98, "Boulevardier", 142m, 13 },
                    { 99, "Sarmatian Negroni", 142m, 13 },
                    { 100, "Bloody Mary", 139m, 13 },
                    { 101, "В-52", 94m, 13 },
                    { 102, "Hop Sour", 125m, 13 },
                    { 103, "Tropical Breath", 142m, 13 },
                    { 104, "Lychee Sour", 130m, 13 },
                    { 105, "Aperol Bridge", 109m, 13 },
                    { 106, "Black Elephant", 123m, 13 },
                    { 107, "Hiroshima", 106m, 13 },
                    { 108, "Дункель", 40m, 14 },
                    { 109, "Празьке", 38m, 14 },
                    { 110, "Сангушко світле", 42m, 14 },
                    { 111, "Бергшлосс світле", 40m, 14 },
                    { 112, "Жигулівське", 35m, 14 },
                    { 113, "Шардоне (біле)", 72m, 15 },
                    { 114, "Совіньйон Блан (біле)", 144m, 15 },
                    { 115, "Касал Мендес Віньйон Верде (біле)", 105m, 15 },
                    { 116, "Каса дель Коппієре Б’янко (біле)", 84m, 15 },
                    { 117, "Каберне (червоне)", 72m, 15 },
                    { 118, "К’янті Каватіна (червоне)", 113m, 15 },
                    { 119, "Каса дель Коппієре Россо (червоне)", 84m, 15 },
                    { 120, "Дорнфельдер (червоне)", 144m, 15 },
                    { 121, "Жан Поль Шене Руж (червоне)", 117m, 15 },
                    { 122, "Столична", 65m, 16 },
                    { 123, "Фінляндія", 77m, 16 },
                    { 124, "Немирів Де Люкс", 46m, 16 },
                    { 125, "Немирів", 33m, 16 },
                    { 126, "Зубрівка Бізон Гранс", 40m, 16 }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price", "SubcategoryId" },
                values: new object[,]
                {
                    { 127, "Зубрівка Золота", 40m, 16 },
                    { 128, "Курвуаз’є V.S.", 250m, 17 },
                    { 129, "Курвуаз’є V.S.O.P", 361m, 17 },
                    { 130, "Арарат 5*", 97m, 17 },
                    { 131, "Болград 5*", 50m, 17 },
                    { 132, "Гудаурі 4*", 50m, 17 },
                    { 133, "Бехерівка", 76m, 18 },
                    { 134, "Єгермейстер", 102m, 18 },
                    { 135, "Кампарі", 60m, 18 },
                    { 136, "Абсент", 143m, 18 },
                    { 137, "Вишнівка", 31m, 18 },
                    { 138, "Лісова ягода", 31m, 18 },
                    { 139, "Смородинівка", 31m, 18 },
                    { 140, "Перцівка", 31m, 18 },
                    { 141, "Гленфідіш 15", 308m, 19 },
                    { 142, "Джек Деніелс", 135m, 19 },
                    { 143, "Блек Лейбл 12", 160m, 19 },
                    { 144, "Ред Лейбл", 106m, 19 },
                    { 145, "Джемесон", 126m, 19 },
                    { 146, "Джим Бім", 110m, 19 },
                    { 147, "Бушмілс Оріджинал", 108m, 19 },
                    { 148, "Ханкі баністер", 105m, 19 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "PinCode", "PositionId" },
                values: new object[,]
                {
                    { 1, "Вікторія Мельник", 1234, 1 },
                    { 2, "Лариса Кописова", 6789, 2 },
                    { 3, "Альберт Бондар", 4321, 2 },
                    { 4, "Ольга Корчик", 9876, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_SubcategoryId",
                table: "Dishes",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDishes_DishId",
                table: "OrdersDishes",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PositionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "OrdersDishes");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrdersStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrdersStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrdersStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Positions",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_Name",
                table: "Employees",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrdersPositions",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersPositions", x => new { x.OrderId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_OrdersPositions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Kitchen");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bar");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_SubcategoryId",
                table: "Positions",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersPositions_PositionId",
                table: "OrdersPositions",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Subcategories_SubcategoryId",
                table: "Positions",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
