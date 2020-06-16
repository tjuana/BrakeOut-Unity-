# BrakeOut-Unity-
It's in Game

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

SELECT Products.name, Category.name
FROM Products LEFT JOIN  Category ON Products.id=Category.productId 
ORDER BY Products.name;

в папку builds сборки для webGL чтобы запустить нужна лиюо mozila либо flag googlechrome --allow-file-access-from-files
