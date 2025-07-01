--Database Schema
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);


--1. Use ROW_NUMBER() to assign a unique rank within each category.
-- This will display the ranked products in each category.
SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNum
FROM Products;

--This will display the top 3 products in each category based on their price.
WITH RankedProducts AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE RowNum <= 3;



--2. Use RANK() and DENSE_RANK() to compare how ties are handled.
-- RANK() skips ranks after ties, while DENSE_RANK() does not.

-- RANK()
-- This will display Shows how RANK() handles ties i.e if same price = same rank then it skips ranks.
SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RankNum
FROM Products;

--This gets top 3 ranks per category, even if ties cause more than 3 products to be included.
WITH RankedProducts AS (
    SELECT *,
           RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE RankNum <= 3;


-- DENSE_RANK()
--It Shows how DENSE_RANK() works i.e no skipping ranks after ties.
SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS DenseRankNum
FROM Products;

--This gets top 3 dense ranks per category, ensuring no gaps in ranking.
WITH RankedProducts AS (
    SELECT *,
           DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE DenseRankNum <= 3;
