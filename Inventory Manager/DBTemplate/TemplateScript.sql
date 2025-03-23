USE [Public]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryReport]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryReport](
	[Product ID] [int] NOT NULL,
	[Product Barcode] [nvarchar](50) NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preference]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preference](
	[name] [nvarchar](80) NULL,
	[value] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Barcode] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Specification] [nvarchar](max) NULL,
	[Date] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductReport]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductReport](
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](70) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier ID] [int] NULL,
	[Supplier Name] [nvarchar](50) NULL,
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NULL,
	[Date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Usertype] [nvarchar](50) NOT NULL,
	[Last modified] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer ID] [int] NOT NULL,
	[Customer Name] [nvarchar](50) NOT NULL,
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[Total Price] [int] NULL,
	[Date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleLog]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer ID] [int] NOT NULL,
	[Customer Name] [nvarchar](50) NOT NULL,
	[Product ID] [int] NOT NULL,
	[Product Barcode] [int] NOT NULL,
	[Product Name] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[Total Price] [int] NULL,
	[Date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Preference] ([name], [value]) VALUES (N'CompanyHeader', N'شركة فلان الفلاني')
GO
INSERT [dbo].[Preference] ([name], [value]) VALUES (N'CompanyPaymentInfo', N'يرجى التسديد نقداً أو على حساب الشركة التالي:')
GO
INSERT [dbo].[Preference] ([name], [value]) VALUES (N'PDFDate', N'21/03/2025')
GO
INSERT [dbo].[Roles] ([Username], [Password], [Usertype], [Last modified]) VALUES (N'malek', N'100 113 103 104 117 118', N'Developer', CAST(N'2025-03-21' AS Date))
GO
INSERT [dbo].[Roles] ([Username], [Password], [Usertype], [Last modified]) VALUES (N'user', N'120 118 104 117', N'user', CAST(N'2025-03-21' AS Date))
GO
INSERT [dbo].[Roles] ([Username], [Password], [Usertype], [Last modified]) VALUES (N'admin', N'100 103 112 108 113', N'admin', CAST(N'2025-03-21' AS Date))
GO
/****** Object:  StoredProcedure [dbo].[AddNewCustomer]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewCustomer] 
    @name NVARCHAR(50)
AS
BEGIN
    INSERT INTO customer (name) 
    VALUES (@name);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewProduct]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewProduct] 
    @barcode INT, 
    @name NVARCHAR(50), 
    @specification NVARCHAR(MAX), 
    @date DATE
AS
BEGIN
    INSERT INTO Product (barcode, name, quantity, specification, date) 
    VALUES (
        @barcode,
        @name,
        0, 
        @specification,
        @date
    );
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewPurchaseBySupplierIdAndProductBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewPurchaseBySupplierIdAndProductBarcode]
    @product_barcode INT,
    @supplier_id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Purchase (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Supplier ID", 
            "Supplier Name", 
            "Quantity", 
            "Price", 
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
            @date  
        FROM 
            supplier c
        JOIN 
            Product p ON (p.barcode = @product_barcode AND c.id = @supplier_id);

        UPDATE Product 
        SET 
            quantity = quantity + @product_quantity,
            Date = @date
        WHERE 
            barcode = @product_barcode;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Barcode" = @product_barcode  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Barcode" = @product_barcode 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.barcode = @product_barcode;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            @product_quantity
        FROM 
            Product p 
        WHERE 
            p.barcode = @product_barcode;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewPurchaseBySupplierIdAndProductId]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewPurchaseBySupplierIdAndProductId]
    @product_id INT,
    @supplier_id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Purchase (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Supplier ID", 
            "Supplier Name", 
            "Quantity", 
            "Price", 
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
            @date 
        FROM 
            supplier c 
        JOIN 
            Product p ON (p.id = @product_id AND c.id = @supplier_id);

        UPDATE Product 
        SET 
            quantity = quantity + @product_quantity, 
            Date = @date 
        WHERE 
            id = @product_id;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product ID" = @product_id 
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product ID" = @product_id 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status 
            FROM 
                Product p 
            WHERE 
                p.id = @product_id;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            @product_quantity 
        FROM 
            Product p 
        WHERE 
            p.id = @product_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewPurchaseBySupplierIdAndProductName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewPurchaseBySupplierIdAndProductName]
    @product_name NVARCHAR(50),
    @supplier_id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Purchase (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Supplier ID", 
            "Supplier Name", 
            "Quantity", 
            "Price", 
            "Date"
        )
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
            @date  
        FROM 
            supplier c 
        JOIN 
            Product p ON (p.name = @product_name AND c.id = @supplier_id);

        UPDATE Product 
        SET 
            quantity = quantity + @product_quantity,
            Date = @date
        WHERE 
            name = @product_name;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Name" = @product_name 
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Name" = @product_name 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.name = @product_name;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            @product_quantity
        FROM 
            Product p 
        WHERE 
            p.name = @product_name;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewPurchaseBySupplierNameAndProductBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewPurchaseBySupplierNameAndProductBarcode]
    @product_barcode INT,
    @supplier_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Purchase (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Supplier ID", 
            "Supplier Name", 
            "Quantity", 
            "Price", 
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
            @date  
        FROM 
            supplier c 
        JOIN 
            Product p ON (p.barcode = @product_barcode AND c.name = @supplier_name);

        UPDATE Product 
        SET 
            quantity = quantity + @product_quantity,
            Date = @date
        WHERE 
            barcode = @product_barcode;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Barcode" = @product_barcode  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Barcode" = @product_barcode 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.barcode = @product_barcode;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            @product_quantity
        FROM 
            Product p 
        WHERE 
            p.barcode = @product_barcode;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewPurchaseBySupplierNameAndProductId]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewPurchaseBySupplierNameAndProductId]
    @product_id INT,
    @supplier_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Purchase (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Supplier ID", 
            "Supplier Name", 
            Quantity, 
            "Price", 
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
            @date  
        FROM 
            supplier c 
        JOIN 
            Product p ON (p.id = @product_id AND c.name = @supplier_name);

        UPDATE Product 
        SET 
            quantity = quantity + @product_quantity,
            Date = @date
        WHERE 
            id = @product_id;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product ID" = @product_id  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product ID" = @product_id 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Barcode", 
                "Product Name", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.barcode, 
                p.name, 
                @date, 
                @product_quantity, 
                @status  
            FROM 
                Product p 
            WHERE 
                p.id = @product_id;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            @product_quantity
        FROM 
            Product p 
        WHERE 
            p.id = @product_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewPurchaseBySupplierNameAndProductName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewPurchaseBySupplierNameAndProductName]
    @product_name NVARCHAR(50),
    @supplier_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Purchase (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Supplier ID", 
            "Supplier Name", 
            "Quantity", 
            "Price", 
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
            @date  
        FROM 
            supplier c 
        JOIN 
            Product p ON (p.name = @product_name AND c.name = @supplier_name);

        UPDATE Product 
        SET 
            quantity = quantity + @product_quantity,
            Date = @date
        WHERE 
            name = @product_name;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Name" = @product_name 
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Name" = @product_name 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.name = @product_name;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            @product_quantity
        FROM 
            Product p 
        WHERE 
            p.name = @product_name;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleByCustomerIdAndProductBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleByCustomerIdAndProductBarcode]
    @product_barcode INT,
    @Customer_id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sale (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c
        JOIN 
            Product p ON (p.barcode = @product_barcode AND c.id = @customer_id);

        UPDATE Product 
        SET 
            quantity = quantity - @product_quantity,
            Date = @date
        WHERE 
            barcode = @product_barcode;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Barcode" = @product_barcode  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Barcode" = @product_barcode 
                AND date = @date; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.barcode = @product_barcode;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            -@product_quantity
        FROM 
            Product p 
        WHERE 
            p.barcode = @product_barcode;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleByCustomerIdAndProductId]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleByCustomerIdAndProductId]
    @product_id INT,
    @Customer_id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sale (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c
        JOIN 
            Product p ON (p.id = @product_id AND c.id = @customer_id);

        UPDATE Product 
        SET 
            quantity = quantity - @product_quantity,
            Date = @date
        WHERE 
            id = @product_id;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product ID" = @product_id  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product ID" = @product_id 
                AND date = @date; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.id = @product_id;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            -@product_quantity
        FROM 
            Product p 
        WHERE 
            p.id = @product_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleByCustomerIdAndProductName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleByCustomerIdAndProductName]
    @product_name NVARCHAR(50),
    @Customer_id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sale (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        )
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.name = @product_name AND c.id = @customer_id);

        UPDATE Product 
        SET 
            quantity = quantity - @product_quantity,
            Date = @date
        WHERE 
            name = @product_name;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Name" = @product_name 
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Name" = @product_name 
                AND date = @date; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.name = @product_name;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            -@product_quantity
        FROM 
            Product p 
        WHERE 
            p.name = @product_name;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleByCustomerNameAndProductBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleByCustomerNameAndProductBarcode]
    @product_barcode INT,
    @Customer_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sale (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.barcode = @product_barcode AND c.name = @customer_name);

        UPDATE Product 
        SET 
            quantity = quantity - @product_quantity,
            Date = @date
        WHERE 
            barcode = @product_barcode;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Barcode" = @product_barcode  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Barcode" = @product_barcode 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.barcode = @product_barcode;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            -@product_quantity
        FROM 
            Product p 
        WHERE 
            p.barcode = @product_barcode;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleByCustomerNameAndProductID]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleByCustomerNameAndProductID]
    @product_id INT,
    @Customer_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sale (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.id = @product_id AND c.name = @customer_name);

        UPDATE Product 
        SET 
            quantity = quantity - @product_quantity,
            Date = @date
        WHERE 
            id = @product_id;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product ID" = @product_id  
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product ID" = @product_id 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status  
            FROM 
                Product p 
            WHERE 
                p.id = @product_id;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            -@product_quantity
        FROM 
            Product p 
        WHERE 
            p.id = @product_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleByCustomerNameAndProductName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleByCustomerNameAndProductName]
    @product_name NVARCHAR(50),
    @Customer_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50),
    @price INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Sale (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.name = @product_name AND c.name = @customer_name);

        UPDATE Product 
        SET 
            quantity = quantity - @product_quantity,
            Date = @date
        WHERE 
            name = @product_name;

        IF EXISTS (
            SELECT quantity 
            FROM ProductReport 
            WHERE "Product Name" = @product_name 
            AND date = @date 
            AND status = @status
        ) 
        BEGIN
            UPDATE ProductReport 
            SET 
                quantity = quantity + @product_quantity 
            WHERE 
                "Product Name" = @product_name 
                AND date = @date 
                AND status = @status; 
        END
        ELSE 
        BEGIN
            INSERT INTO ProductReport (
                "Product ID", 
                "Product Name", 
                "Product Barcode", 
                date, 
                quantity, 
                status
            ) 
            SELECT 
                p.id, 
                p.name, 
                p.barcode, 
                @date, 
                @product_quantity, 
                @status
            FROM 
                Product p 
            WHERE 
                p.name = @product_name;
        END

        INSERT INTO InventoryReport (
            "Product ID", 
            "Product Name", 
            "Product Barcode", 
            date, 
            quantity
        ) 
        SELECT 
            p.id, 
            p.name, 
            p.barcode, 
            @date, 
            -@product_quantity
        FROM 
            Product p 
        WHERE 
            p.name = @product_name;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleLogByCustomerIdAndProductBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleLogByCustomerIdAndProductBarcode]
    @product_barcode INT,
    @Customer_id INT,
    @date DATE,
    @product_quantity INT,
    @price INT
AS
BEGIN
        INSERT INTO SaleLog (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c
        JOIN 
            Product p ON (p.barcode = @product_barcode AND c.id = @customer_id);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleLogByCustomerIdAndProductId]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleLogByCustomerIdAndProductId]
    @product_id INT,
    @Customer_id INT,
    @date DATE,
    @product_quantity INT,
    @price INT
AS
BEGIN
        INSERT INTO SaleLog (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c
        JOIN 
            Product p ON (p.id = @product_id AND c.id = @customer_id);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleLogByCustomerIdAndProductName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleLogByCustomerIdAndProductName]
    @product_name NVARCHAR(50),
    @Customer_id INT,
    @date DATE,
    @product_quantity INT,
    @price INT
AS
BEGIN
        INSERT INTO SaleLog (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        )
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.name = @product_name AND c.id = @customer_id);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleLogByCustomerNameAndProductBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleLogByCustomerNameAndProductBarcode]
    @product_barcode INT,
    @Customer_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @price INT
AS
BEGIN
        INSERT INTO SaleLog (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.barcode = @product_barcode AND c.name = @customer_name);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleLogByCustomerNameAndProductID]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleLogByCustomerNameAndProductID]
    @product_id INT,
    @Customer_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @price INT
AS
BEGIN
        INSERT INTO SaleLog (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.id = @product_id AND c.name = @customer_name);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSaleLogByCustomerNameAndProductName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSaleLogByCustomerNameAndProductName]
    @product_name NVARCHAR(50),
    @Customer_name NVARCHAR(50),
    @date DATE,
    @product_quantity INT,
    @price INT
AS
BEGIN
        INSERT INTO SaleLog (
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            "Customer ID", 
            "Customer Name", 
            "Quantity", 
            "Price", 
			"Total Price" ,
            "Date"
        ) 
        SELECT 
            p.id, 
            p.barcode, 
            p.name, 
            c.id, 
            c.name, 
            @product_quantity, 
            @price, 
			@product_quantity * @price ,
            @date  
        FROM 
            Customer c 
        JOIN 
            Product p ON (p.name = @product_name AND c.name = @customer_name);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewSupplier]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewSupplier] 
    @name NVARCHAR(50)
AS 
BEGIN
    INSERT INTO Supplier (name) 
    VALUES (@name);
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewUser]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewUser]
    @username NVARCHAR(50),
    @password NVARCHAR(MAX),
    @usertype NVARCHAR(50),
    @date DATE
AS
BEGIN
    INSERT INTO Roles 
    VALUES (@username, @password, @usertype, @date);
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomerById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteCustomerById]
    @id INT 
AS
BEGIN
    DELETE FROM Customer 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomerByName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteCustomerByName]
    @name NVARCHAR(50) 
AS
BEGIN
    DELETE FROM Customer 
    WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductByBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteProductByBarcode]
    @barcode INT 
AS
BEGIN
    DELETE FROM Product 
    WHERE barcode = @barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteProductById]
    @id INT 
AS
BEGIN
    DELETE FROM Product 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductByName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteProductByName]
    @name NVARCHAR(50)
AS
BEGIN
    DELETE FROM Product 
    WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePurchase]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeletePurchase]
    @id INT,
    @date DATE,
    @status NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Product
        SET 
            Product.quantity = Product.quantity - Purchase.quantity, 
            Product.date = @date    
        FROM 
            Product
        JOIN 
            Purchase ON Product.id = Purchase."Product ID"
        WHERE 
            Purchase.id = @id;

        UPDATE ProductReport 
        SET 
            quantity = quantity - (SELECT quantity FROM Purchase WHERE id = @id)
        WHERE 
            "Product ID" = (SELECT "Product ID" FROM Purchase WHERE ID = @id)
            AND date = (SELECT date FROM Purchase WHERE id = @id)
            AND status = @status;

        INSERT INTO InventoryReport
        SELECT 
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            -quantity, 
            @date
        FROM 
            Purchase
        WHERE 
            Purchase.id = @id;

        DELETE FROM Purchase WHERE id = @id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSale]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteSale]
    @id INT,
    @date DATE,
    @status NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Product
        SET 
            Product.quantity = Product.quantity + Sale.quantity
        FROM 
            Product
        JOIN 
            Sale ON Product.id = Sale."Product ID"
        WHERE 
            Sale.id = @id;

        UPDATE ProductReport 
        SET 
            quantity = quantity - (SELECT quantity FROM Sale WHERE id = @id)
        WHERE 
            "Product ID" = (SELECT "Product ID" FROM Sale WHERE ID = @id)
            AND status = @status;

        INSERT INTO InventoryReport
        SELECT 
            "Product ID", 
            "Product Barcode", 
            "Product Name", 
            quantity, 
            @date
        FROM 
            Sale
        WHERE 
            Sale.id = @id;

        DELETE FROM Sale WHERE id = @id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSaleLog]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteSaleLog]
    @id INT
AS
BEGIN
        DELETE FROM SaleLog WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSupplierById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteSupplierById]
    @id INT 
AS
BEGIN
    DELETE FROM Supplier 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSupplierByName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteSupplierByName]
    @name NVARCHAR(50) 
AS
BEGIN
    DELETE FROM Supplier 
    WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteUser]
    @username NVARCHAR(50)
AS
BEGIN
    DELETE FROM Roles
    WHERE username = @username;
END
GO
/****** Object:  StoredProcedure [dbo].[DoesUserExist]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DoesUserExist]
    @usrname NVARCHAR(50)
AS
BEGIN
    IF (SELECT username 
        FROM Roles
        WHERE username = @usrname) = @usrname
    BEGIN
        SELECT 'true';
    END
    ELSE 
    BEGIN
        SELECT 'false';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[EditCurrentUserPassword]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditCurrentUserPassword]
    @password NVARCHAR(MAX),
    @usertype NVARCHAR(50),
    @username NVARCHAR(50)
AS 
BEGIN
    UPDATE Roles
			SET Password = @password
			WHERE usertype = @usertype 
			AND username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[EditCustomerName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditCustomerName] 
    @id INT,
    @name NVARCHAR(50)
AS 
BEGIN
    UPDATE customer 
    SET name = @name 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditProductNameByBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditProductNameByBarcode] 
    @barcode INT, 
    @name NVARCHAR(50)
AS 
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE Product 
        SET name = @name 
        WHERE barcode = @barcode;

        UPDATE ProductReport 
        SET "Product Name" = @name 
        WHERE "Product Barcode" = @barcode;

        UPDATE InventoryReport 
        SET "Product Name" = @name 
        WHERE "Product Barcode" = @barcode;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[EditProductNameById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditProductNameById] 
    @id INT, 
    @name NVARCHAR(50)
AS 
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE Product 
        SET name = @name 
        WHERE id = @id;

        UPDATE ProductReport 
        SET "Product Name" = @name 
        WHERE "Product ID" = @id;

        UPDATE InventoryReport 
        SET "Product Name" = @name 
        WHERE "Product ID" = @id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[EditPurchase]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditPurchase]
    @id INT,
    @date DATE,
    @product_quantity INT,
    @status NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE ProductReport
        SET quantity = quantity + @product_quantity - 
            (SELECT quantity FROM Purchase WHERE id = @id)
        WHERE date = 
            (SELECT date FROM Purchase WHERE id = @id)
            AND "Product ID" = 
            (SELECT "Product ID" FROM Purchase WHERE id = @id)
            AND status = @status;

        INSERT INTO InventoryReport
        SELECT "Product ID", "Product Barcode", "Product Name", @product_quantity - quantity, @date
        FROM Purchase
        WHERE Purchase.id = @id;

        UPDATE Product
        SET Product.quantity = Product.quantity + (
            SELECT @product_quantity - pu.quantity
            FROM Purchase pu
            WHERE pu.id = @id
        )
        WHERE Product.id = (
            SELECT pu."Product ID"
            FROM Purchase pu
            WHERE pu.id = @id
        );

        UPDATE Purchase
        SET quantity = @product_quantity
        WHERE id = @id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[EditPurchaseCost]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditPurchaseCost]
	@id INT ,
	@product_cost INT
AS
	UPDATE Purchase
	SET Price = @product_cost
	WHERE ID = @id
GO
/****** Object:  StoredProcedure [dbo].[EditSaleCost]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditSaleCost]
	@id INT,
	@product_cost INT
AS 
	UPDATE Sale
	SET Price = @product_cost ,
	[Total Price] = Quantity * @product_cost
	WHERE ID = @id;
GO
/****** Object:  StoredProcedure [dbo].[EditSaleLogCost]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditSaleLogCost]
	@id INT,
	@product_cost INT
AS 
	UPDATE SaleLog
	SET Price = @product_cost ,
	[Total Price] = Quantity * @product_cost
	WHERE ID = @id;
GO
/****** Object:  StoredProcedure [dbo].[EditSaleLogQuantity]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditSaleLogQuantity]
    @id INT,
    @product_quantity INT,
    @date DATE,
    @status NVARCHAR(50)
AS
BEGIN
        UPDATE SaleLog	
        SET quantity = @product_quantity,
		[Total Price] = @product_quantity * [Price]  ,
            Date = @date
        WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditSaleQuantity]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditSaleQuantity]
    @id INT,
    @product_quantity INT,
    @date DATE,
    @status NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE ProductReport
        SET quantity = quantity + @product_quantity - 
            (SELECT quantity FROM Sale WHERE id = @id)
        WHERE date = 
            (SELECT date FROM Sale WHERE id = @id)
            AND "Product ID" = 
            (SELECT "Product ID" FROM Sale WHERE id = @id)
            AND status = @status;

        INSERT INTO InventoryReport
        SELECT "Product ID", "Product Barcode", "Product Name", quantity - @product_quantity, @date
        FROM Sale
        WHERE Sale.id = @id;

        UPDATE Product
        SET Product.quantity = Product.quantity - (
            SELECT @product_quantity - pu.quantity
            FROM Sale pu
            WHERE pu.id = @id
        )
        WHERE Product.id = (
            SELECT pu."Product ID"
            FROM Sale pu
            WHERE pu.id = @id
        );

        UPDATE Sale
        SET quantity = @product_quantity,
		[Total Price] = @product_quantity * [Price]  ,
            Date = @date
        WHERE id = @id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[EditSpecificationByBarcode]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditSpecificationByBarcode]
    @barcode INT,
    @specification NVARCHAR(MAX)
AS 
BEGIN
    UPDATE Product 
    SET specification = @specification
    WHERE barcode = @barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[EditSpecificationById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditSpecificationById] 
    @id INT,
    @specification NVARCHAR(MAX)
AS 
BEGIN
    UPDATE Product 
    SET specification = @specification
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditSpecificationByName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditSpecificationByName]
    @name NVARCHAR(50),
    @specification NVARCHAR(MAX)
AS 
BEGIN
    UPDATE Product 
    SET specification = @specification
    WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[EditSupplierName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditSupplierName]
    @id INT,
    @name NVARCHAR(50)
AS 
BEGIN
    UPDATE Supplier 
    SET name = @name 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[EditUserPassword]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditUserPassword]
    @pass NVARCHAR(MAX),
    @date DATE,
    @username NVARCHAR(50)
AS 
BEGIN
    UPDATE Roles
    SET password = @pass,
        "Last Modified" = @date
    WHERE username = @username;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedCustomersNumberById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedCustomersNumberById] 
    @id INT
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Customer 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedCustomersNumberByName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedCustomersNumberByName] 
    @name NVARCHAR(50)
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Customer 
    WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedCustomersNumberByNameOrId]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedCustomersNumberByNameOrId]
    @id INT,
    @name NVARCHAR(50)
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Customer 
    WHERE name = @name 
       OR id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedProductsNumberByBarcodeOrName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedProductsNumberByBarcodeOrName] 
    @name NVARCHAR(50), 
    @barcode INT
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Product 
    WHERE name = @name 
       OR barcode = @barcode;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedProductsNumberByIdBarcodeName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedProductsNumberByIdBarcodeName] 
    @id INT, 
    @barcode INT, 
    @name NVARCHAR(50)
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Product 
    WHERE id = @id 
       OR barcode = @barcode 
       OR name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedPurchasesNumberById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedPurchasesNumberById] 
    @id INT
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Purchase 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedSalesLogNumberById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedSalesLogNumberById] 
    @id INT
AS 
BEGIN
    SELECT COUNT(*) 
    FROM SaleLog
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedSalesNumberById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedSalesNumberById] 
    @id INT
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Sale 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedSuppliersByName]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedSuppliersByName] 
    @name NVARCHAR(50)
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Supplier 
    WHERE name = @name;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedSuppliersNumberById]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedSuppliersNumberById]
    @id INT
AS 
BEGIN
    SELECT COUNT(*)
    FROM Supplier 
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetExistedSuppliersNumberByNameOrId]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExistedSuppliersNumberByNameOrId]
    @id INT, 
    @name NVARCHAR(50)
AS 
BEGIN
    SELECT COUNT(*) 
    FROM Supplier 
    WHERE name = @name 
       OR id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetPrefValue]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPrefValue]
	@name nvarchar(80)
AS
	SELECT value 
	FROM Preference
	WHERE name = @name
GO
/****** Object:  StoredProcedure [dbo].[GetUserRole]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUserRole]
    @username NVARCHAR(50) ,
    @password NVARCHAR(MAX)
AS 
BEGIN
    SELECT Usertype 
			FROM Roles
			WHERE Username = @username
			AND Password = @password
END
GO
/****** Object:  StoredProcedure [dbo].[IsPasswordCorrect]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[IsPasswordCorrect]
    @username NVARCHAR(50) ,
    @password NVARCHAR(MAX)
AS 
BEGIN
    IF EXISTS (SELECT 1 
				 FROM Roles 
				 WHERE username = @username AND Password = @password)
				 SELECT 'true'
				 ELSE 
				 SELECT 'false'
END
GO
/****** Object:  StoredProcedure [dbo].[SetPrefValue]    Script Date: 21/03/2025 03:33:09 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetPrefValue]
	@name nvarchar(80) ,
	@value nvarchar(500)
AS
	UPDATE Preference
	SET value = @value
	WHERE name = @name
GO
