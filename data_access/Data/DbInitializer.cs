using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    public class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(new Hall[]
            {
                new Hall() { Id = 1, Name = "Бар"},
                new Hall() { Id = 2, Name = "Основний зал"},
                new Hall() { Id = 3, Name = "Літня тераса"},
            });
            modelBuilder.Entity<Entities.Table>().HasData(new Entities.Table[]
            {
                new Entities.Table() { Id = 1, HallId = 2, Number = "1"},
                new Entities.Table() { Id = 2, HallId = 2, Number = "2"},
                new Entities.Table() { Id = 3, HallId = 2, Number = "3"},
                new Entities.Table() { Id = 4, HallId = 2, Number = "4"},
                new Entities.Table() { Id = 5, HallId = 2, Number = "5"},
                new Entities.Table() { Id = 6, HallId = 2, Number = "6"},
                new Entities.Table() { Id = 7, HallId = 2, Number = "7"},
                new Entities.Table() { Id = 8, HallId = 2, Number = "8"},
                new Entities.Table() { Id = 9, HallId = 2, Number = "9"},
                new Entities.Table() { Id = 10, HallId = 2, Number = "10"},
                new Entities.Table() { Id = 11, HallId = 1, Number = "1"},
                new Entities.Table() { Id = 12, HallId = 1, Number = "2"},
                new Entities.Table() { Id = 13, HallId = 1, Number = "3"},
                new Entities.Table() { Id = 14, HallId = 1, Number = "4"},
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category() { Id = 1, Name = "Кухня" },
                new Category() { Id = 2, Name = "Бар" },
            });
            modelBuilder.Entity<Subcategory>().HasData(new Subcategory[]
            {
                new Subcategory() { Id = 1, CategoryId = 1, Name = "Гарніри"},
                new Subcategory() { Id = 2, CategoryId = 1, Name = "Гарячі закуски"},
                new Subcategory() { Id = 3, CategoryId = 1, Name = "Закуски"},
                new Subcategory() { Id = 4, CategoryId = 1, Name = "Перші страви"},
                new Subcategory() { Id = 5, CategoryId = 1, Name = "Салати"},
                new Subcategory() { Id = 6, CategoryId = 1, Name = "Риба та морепродукти"},
                new Subcategory() { Id = 7, CategoryId = 1, Name = "М'ясо & Птиця"},
                new Subcategory() { Id = 8, CategoryId = 1, Name = "Соуси"},
                new Subcategory() { Id = 9, CategoryId = 1, Name = "Десерти"},
                new Subcategory() { Id = 10, CategoryId = 1, Name = "Морозиво"},
                new Subcategory() { Id = 11, CategoryId = 2, Name = "Безалкогольні напої"},
                new Subcategory() { Id = 12, CategoryId = 2, Name = "Гарячі напої"},
                new Subcategory() { Id = 13, CategoryId = 2, Name = "Коктейлі алкогольні"},
                new Subcategory() { Id = 14, CategoryId = 2, Name = "Пиво"},
                new Subcategory() { Id = 15, CategoryId = 2, Name = "Вино"},
                new Subcategory() { Id = 16, CategoryId = 2, Name = "Горілка"},
                new Subcategory() { Id = 17, CategoryId = 2, Name = "Коньяк"},
                new Subcategory() { Id = 18, CategoryId = 2, Name = "Настоянки"},
                new Subcategory() { Id = 19, CategoryId = 2, Name = "Віскі"},
            });
            modelBuilder.Entity<Dish>().HasData(new Dish[]
            {
                new Dish() {Id = 1, SubcategoryId = 1, Name = "Картопля по-селянськи", Price = 65},
                new Dish() {Id = 2, SubcategoryId = 1, Name = "Картопля з сиром Чеддер", Price = 69},
                new Dish() {Id = 3, SubcategoryId = 1, Name = "Картопляне пюре", Price = 52},
                new Dish() {Id = 4, SubcategoryId = 1, Name = "Гречка з грибами", Price = 56},
                new Dish() {Id = 5, SubcategoryId = 1, Name = "Картопля смажена", Price = 68},
                new Dish() {Id = 6, SubcategoryId = 1, Name = "Локшина домашня", Price = 52},
                new Dish() {Id = 7, SubcategoryId = 2, Name = "Тако", Price = 129},
                new Dish() {Id = 8, SubcategoryId = 2, Name = "Самоса в лаваші", Price = 127},
                new Dish() {Id = 9, SubcategoryId = 2, Name = "Сир по-чешськи", Price = 103},
                new Dish() {Id = 10, SubcategoryId = 2, Name = "Дерун", Price = 125},
                new Dish() {Id = 11, SubcategoryId = 2, Name = "Кров'янка з шукрутом", Price = 117},
                new Dish() {Id = 12, SubcategoryId = 2, Name = "Ковбаски курячі", Price = 139},
                new Dish() {Id = 13, SubcategoryId = 2, Name = "Ковбаски свинні", Price = 144},
                new Dish() {Id = 14, SubcategoryId = 2, Name = "Ковбаски телячі", Price = 148},
                new Dish() {Id = 15, SubcategoryId = 2, Name = "Асорті ковбас", Price = 463},
                new Dish() {Id = 16, SubcategoryId = 3, Name = "Картопляні чіпси", Price = 105},
                new Dish() {Id = 17, SubcategoryId = 3, Name = "Пивна тарілка", Price = 103},
                new Dish() {Id = 18, SubcategoryId = 3, Name = "М'ясна тарілка до пива", Price = 173},
                new Dish() {Id = 19, SubcategoryId = 3, Name = "Дошка з пивними закусками", Price = 172},
                new Dish() {Id = 20, SubcategoryId = 3, Name = "Сирна тарілка", Price = 316},
                new Dish() {Id = 21, SubcategoryId = 3, Name = "М'ясна тарілка", Price = 172},
                new Dish() {Id = 22, SubcategoryId = 3, Name = "Дошка з копченостями", Price = 215},
                new Dish() {Id = 23, SubcategoryId = 3, Name = "Рибна тарілка", Price = 182},
                new Dish() {Id = 24, SubcategoryId = 3, Name = "Брускети з копченим сомом", Price = 105},
                new Dish() {Id = 25, SubcategoryId = 3, Name = "Соління", Price = 120},
                new Dish() {Id = 26, SubcategoryId = 3, Name = "Оселедець", Price = 113},
                new Dish() {Id = 27, SubcategoryId = 3, Name = "Тартар з яловичини", Price = 186},
                new Dish() {Id = 28, SubcategoryId = 4, Name = "Борщ український", Price = 119},
                new Dish() {Id = 29, SubcategoryId = 4, Name = "Бульйон з телятини", Price = 133},
                new Dish() {Id = 30, SubcategoryId = 4, Name = "Бограч", Price = 119},
                new Dish() {Id = 31, SubcategoryId = 4, Name = "Грибна юшка", Price = 105},
                new Dish() {Id = 32, SubcategoryId = 5, Name = "Грецький салат", Price = 120},
                new Dish() {Id = 33, SubcategoryId = 5, Name = "Салат з копченим язиком", Price = 174},
                new Dish() {Id = 34, SubcategoryId = 5, Name = "Теплий салат з телятини", Price = 200},
                new Dish() {Id = 35, SubcategoryId = 5, Name = "Салат із печеним буряком", Price = 93},
                new Dish() {Id = 36, SubcategoryId = 5, Name = "Салат зі свіжих овочів", Price = 114},
                new Dish() {Id = 37, SubcategoryId = 5, Name = "Салат Цезар", Price = 157},
                new Dish() {Id = 38, SubcategoryId = 5, Name = "Салат Оселедець під шубою", Price = 92},
                new Dish() {Id = 39, SubcategoryId = 5, Name = "Салат з лососем", Price = 226},
                new Dish() {Id = 40, SubcategoryId = 5, Name = "Салат Мімоза", Price = 92},
                new Dish() {Id = 41, SubcategoryId = 5, Name = "Салат Олів'є", Price = 119},
                new Dish() {Id = 42, SubcategoryId = 6, Name = "Креветки у сухарях панко", Price = 238},
                new Dish() {Id = 43, SubcategoryId = 6, Name = "Стейк з лосося", Price = 442},
                new Dish() {Id = 44, SubcategoryId = 6, Name = "Мідії у вершковому соусі", Price = 252},
                new Dish() {Id = 45, SubcategoryId = 6, Name = "Мойва в пивному клярі", Price = 142},
                new Dish() {Id = 46, SubcategoryId = 6, Name = "Короп по-чеськи", Price = 156},
                new Dish() {Id = 47, SubcategoryId = 6, Name = "Короп фрі", Price = 76},
                new Dish() {Id = 48, SubcategoryId = 6, Name = "Копчена річкова форель", Price = 100},
                new Dish() {Id = 49, SubcategoryId = 7, Name = "Курячі гомілки", Price = 142},
                new Dish() {Id = 50, SubcategoryId = 7, Name = "Курячі крильця buffalo", Price = 142},
                new Dish() {Id = 51, SubcategoryId = 7, Name = "Бургер яловичий з картоплею по-селянськи", Price = 215},
                new Dish() {Id = 52, SubcategoryId = 7, Name = "Підкопчений язик", Price = 221},
                new Dish() {Id = 53, SubcategoryId = 7, Name = "Куряче філе в беконі", Price = 215},
                new Dish() {Id = 54, SubcategoryId = 7, Name = "Яловичий медальйон", Price = 330},
                new Dish() {Id = 55, SubcategoryId = 7, Name = "Перепела", Price = 214},
                new Dish() {Id = 56, SubcategoryId = 7, Name = "Качина ніжка конфі", Price = 218},
                new Dish() {Id = 57, SubcategoryId = 7, Name = "Пів качки", Price = 678},
                new Dish() {Id = 58, SubcategoryId = 7, Name = "Печінка теляча", Price = 169},
                new Dish() {Id = 59, SubcategoryId = 7, Name = "Телячі щоки з хумусом", Price = 175},
                new Dish() {Id = 60, SubcategoryId = 7, Name = "Волинський шніцель", Price = 182},
                new Dish() {Id = 61, SubcategoryId = 7, Name = "Стейк свинний на кістці", Price = 103},
                new Dish() {Id = 62, SubcategoryId = 7, Name = "Баварські реберця", Price = 254},
                new Dish() {Id = 63, SubcategoryId = 7, Name = "Дошка з закусками", Price = 787},
                new Dish() {Id = 64, SubcategoryId = 7, Name = "Рулька свинна", Price = 409},
                new Dish() {Id = 65, SubcategoryId = 8, Name = "Трюфельний", Price = 36},
                new Dish() {Id = 66, SubcategoryId = 8, Name = "Пікантний з каррі", Price = 36},
                new Dish() {Id = 67, SubcategoryId = 8, Name = "Blue Cheese", Price = 36},
                new Dish() {Id = 68, SubcategoryId = 8, Name = "BBQ", Price = 30},
                new Dish() {Id = 69, SubcategoryId = 8, Name = "Тартар", Price = 30},
                new Dish() {Id = 70, SubcategoryId = 8, Name = "Пілатті", Price = 30},
                new Dish() {Id = 71, SubcategoryId = 9, Name = "Чізкейк", Price = 112},
                new Dish() {Id = 72, SubcategoryId = 9, Name = "Яблучний штрудель", Price = 89},
                new Dish() {Id = 73, SubcategoryId = 9, Name = "Creme Brulee", Price = 78},
                new Dish() {Id = 74, SubcategoryId = 10, Name = "Бананове", Price = 62},
                new Dish() {Id = 75, SubcategoryId = 10, Name = "Шоколадне", Price = 62},
                new Dish() {Id = 76, SubcategoryId = 10, Name = "Пломбір", Price = 50},
                new Dish() {Id = 77, SubcategoryId = 10, Name = "З джемами", Price = 60},
                new Dish() {Id = 78, SubcategoryId = 11, Name = "Мохіто без алкогольне", Price = 72},
                new Dish() {Id = 79, SubcategoryId = 11, Name = "Лимонад", Price = 66},
                new Dish() {Id = 80, SubcategoryId = 11, Name = "Узвар", Price = 80},
                new Dish() {Id = 81, SubcategoryId = 11, Name = "Боржомі", Price = 66},
                new Dish() {Id = 82, SubcategoryId = 11, Name = "Моршинська", Price = 33},
                new Dish() {Id = 83, SubcategoryId = 11, Name = "Pepsi", Price = 47},
                new Dish() {Id = 84, SubcategoryId = 11, Name = "Сік", Price = 36},
                new Dish() {Id = 85, SubcategoryId = 12, Name = "Чай класичний", Price = 55},
                new Dish() {Id = 86, SubcategoryId = 12, Name = "Чай фірмовий", Price = 60},
                new Dish() {Id = 87, SubcategoryId = 12, Name = "Еспресо", Price = 32},
                new Dish() {Id = 88, SubcategoryId = 12, Name = "Американо", Price = 32},
                new Dish() {Id = 89, SubcategoryId = 12, Name = "Капучіно", Price = 38},
                new Dish() {Id = 90, SubcategoryId = 12, Name = "Лате", Price = 43},
                new Dish() {Id = 91, SubcategoryId = 13, Name = "Aperol Shpritz", Price = 143},
                new Dish() {Id = 92, SubcategoryId = 13, Name = "Black Shpritz", Price = 130},
                new Dish() {Id = 93, SubcategoryId = 13, Name = "Hugo", Price = 142},
                new Dish() {Id = 94, SubcategoryId = 13, Name = "Bramble", Price = 142},
                new Dish() {Id = 95, SubcategoryId = 13, Name = "Tommy's Margo", Price = 162},
                new Dish() {Id = 96, SubcategoryId = 13, Name = "Amaro Sour", Price = 162},
                new Dish() {Id = 97, SubcategoryId = 13, Name = "Бандерівський Mule", Price = 130},
                new Dish() {Id = 98, SubcategoryId = 13, Name = "Boulevardier", Price = 142},
                new Dish() {Id = 99, SubcategoryId = 13, Name = "Sarmatian Negroni", Price = 142},
                new Dish() {Id = 100, SubcategoryId = 13, Name = "Bloody Mary", Price = 139},
                new Dish() {Id = 101, SubcategoryId = 13, Name = "В-52", Price = 94},
                new Dish() {Id = 102, SubcategoryId = 13, Name = "Hop Sour", Price = 125},
                new Dish() {Id = 103, SubcategoryId = 13, Name = "Tropical Breath", Price = 142},
                new Dish() {Id = 104, SubcategoryId = 13, Name = "Lychee Sour", Price = 130},
                new Dish() {Id = 105, SubcategoryId = 13, Name = "Aperol Bridge", Price = 109},
                new Dish() {Id = 106, SubcategoryId = 13, Name = "Black Elephant", Price = 123},
                new Dish() {Id = 107, SubcategoryId = 13, Name = "Hiroshima", Price = 106},
                new Dish() {Id = 108, SubcategoryId = 14, Name = "Дункель", Price = 40},
                new Dish() {Id = 109, SubcategoryId = 14, Name = "Празьке", Price = 38},
                new Dish() {Id = 110, SubcategoryId = 14, Name = "Сангушко світле", Price = 42},
                new Dish() {Id = 111, SubcategoryId = 14, Name = "Бергшлосс світле", Price = 40},
                new Dish() {Id = 112, SubcategoryId = 14, Name = "Жигулівське", Price = 35},
                new Dish() {Id = 113, SubcategoryId = 15, Name = "Шардоне (біле)", Price = 72},
                new Dish() {Id = 114, SubcategoryId = 15, Name = "Совіньйон Блан (біле)", Price = 144},
                new Dish() {Id = 115, SubcategoryId = 15, Name = "Касал Мендес Віньйон Верде (біле)", Price = 105},
                new Dish() {Id = 116, SubcategoryId = 15, Name = "Каса дель Коппієре Б’янко (біле)", Price = 84},
                new Dish() {Id = 117, SubcategoryId = 15, Name = "Каберне (червоне)", Price = 72},
                new Dish() {Id = 118, SubcategoryId = 15, Name = "К’янті Каватіна (червоне)", Price = 113},
                new Dish() {Id = 119, SubcategoryId = 15, Name = "Каса дель Коппієре Россо (червоне)", Price = 84},
                new Dish() {Id = 120, SubcategoryId = 15, Name = "Дорнфельдер (червоне)", Price = 144},
                new Dish() {Id = 121, SubcategoryId = 15, Name = "Жан Поль Шене Руж (червоне)", Price = 117},
                new Dish() {Id = 122, SubcategoryId = 16, Name = "Столична", Price = 65},
                new Dish() {Id = 123, SubcategoryId = 16, Name = "Фінляндія", Price = 77},
                new Dish() {Id = 124, SubcategoryId = 16, Name = "Немирів Де Люкс", Price = 46},
                new Dish() {Id = 125, SubcategoryId = 16, Name = "Немирів", Price = 33},
                new Dish() {Id = 126, SubcategoryId = 16, Name = "Зубрівка Бізон Гранс", Price = 40},
                new Dish() {Id = 127, SubcategoryId = 16, Name = "Зубрівка Золота", Price = 40},
                new Dish() {Id = 128, SubcategoryId = 17, Name = "Курвуаз’є V.S.", Price = 250},
                new Dish() {Id = 129, SubcategoryId = 17, Name = "Курвуаз’є V.S.O.P", Price = 361},
                new Dish() {Id = 130, SubcategoryId = 17, Name = "Арарат 5*", Price = 97},
                new Dish() {Id = 131, SubcategoryId = 17, Name = "Болград 5*", Price = 50},
                new Dish() {Id = 132, SubcategoryId = 17, Name = "Гудаурі 4*", Price = 50},
                new Dish() {Id = 133, SubcategoryId = 18, Name = "Бехерівка", Price = 76},
                new Dish() {Id = 134, SubcategoryId = 18, Name = "Єгермейстер", Price = 102},
                new Dish() {Id = 135, SubcategoryId = 18, Name = "Кампарі", Price = 60},
                new Dish() {Id = 136, SubcategoryId = 18, Name = "Абсент", Price = 143},
                new Dish() {Id = 137, SubcategoryId = 18, Name = "Вишнівка", Price = 31},
                new Dish() {Id = 138, SubcategoryId = 18, Name = "Лісова ягода", Price = 31},
                new Dish() {Id = 139, SubcategoryId = 18, Name = "Смородинівка", Price = 31},
                new Dish() {Id = 140, SubcategoryId = 18, Name = "Перцівка", Price = 31},
                new Dish() {Id = 141, SubcategoryId = 19, Name = "Гленфідіш 15", Price = 308},
                new Dish() {Id = 142, SubcategoryId = 19, Name = "Джек Деніелс", Price = 135},
                new Dish() {Id = 143, SubcategoryId = 19, Name = "Блек Лейбл 12", Price = 160},
                new Dish() {Id = 144, SubcategoryId = 19, Name = "Ред Лейбл", Price = 106},
                new Dish() {Id = 145, SubcategoryId = 19, Name = "Джемесон", Price = 126},
                new Dish() {Id = 146, SubcategoryId = 19, Name = "Джим Бім", Price = 110},
                new Dish() {Id = 147, SubcategoryId = 19, Name = "Бушмілс Оріджинал", Price = 108},
                new Dish() {Id = 148, SubcategoryId = 19, Name = "Ханкі баністер", Price = 105},
            });
            modelBuilder.Entity<Payment>().HasData(new Payment[]
            {
                new Payment() {Id = 1, PaymentType = "Готівка"},
                new Payment() {Id = 2, PaymentType = "Картка"}
            });
            modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus[]
            {
                new OrderStatus() {Id = 1, Name = "Відкрите"},
                new OrderStatus() {Id = 2, Name = "Закрите без оплати"},
                new OrderStatus() {Id = 3, Name = "Закрите та оплачене"}
            });
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                new Position() {Id = 1, Name = "Адміністратор"},
                new Position() {Id = 2, Name = "Офіціант"},
            });
            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                new Employee() {Id = 1, Name = "Вікторія Мельник", PinCode = 1234, PositionId = 1},
                new Employee() {Id = 2, Name = "Лариса Кописова", PinCode = 6789, PositionId = 2},
                new Employee() {Id = 3, Name = "Альберт Бондар", PinCode = 4321, PositionId = 2},
                new Employee() {Id = 4, Name = "Ольга Корчик", PinCode = 9876, PositionId = 2}
            });
        }
    }
}
