CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Users` (
    `id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `userName` nvarchar(50) NOT NULL,
    `phoneNo` nvarchar(25) NOT NULL,
    `password` nvarchar(50) NOT NULL,
    `createdDateTime` datetime NOT NULL,
    `updatedDateTime` datetime NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220326160318_DBInit', '6.0.3');

COMMIT;

START TRANSACTION;

CREATE TABLE `PaymentMethods` (
    `id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `name` nvarchar(100) NOT NULL,
    `discountPercent` int NOT NULL DEFAULT 0,
    `createdDateTime` datetime NOT NULL,
    `updatedDateTime` datetime NULL,
    CONSTRAINT `PK_PaymentMethods` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220326163414_PaymentMethodsAdd', '6.0.3');

COMMIT;

START TRANSACTION;

CREATE TABLE `BuyTypes` (
    `id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `isMyself` int NOT NULL,
    `isGiftOthers` int NOT NULL,
    `eVoucher_maxlimit` int NOT NULL DEFAULT 0,
    `user_maxlimit` int NOT NULL DEFAULT 0,
    `createdDateTime` datetime NOT NULL,
    `updatedDateTime` datetime NULL,
    CONSTRAINT `PK_BuyTypes` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220326180015_BuyTypesAdd', '6.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE `BuyTypes` CHANGE `user_maxlimit` `giftUser_maxlimit` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220326180620_BuyTypesAdd_ChangeColumnName', '6.0.3');

COMMIT;

START TRANSACTION;

CREATE TABLE `EVouchers` (
    `id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `title` nvarchar(100) NOT NULL,
    `description` nvarchar(1000) NOT NULL,
    `expiryDate` datetime NOT NULL,
    `image` nvarchar(300) NOT NULL,
    `amount` int NOT NULL,
    `quantity` int NOT NULL,
    `isActive` int NOT NULL,
    `user_id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `userName` nvarchar(50) NOT NULL,
    `phoneNo` nvarchar(25) NOT NULL,
    `qrCode` nvarchar(300) NOT NULL,
    `createdDateTime` datetime NOT NULL,
    `updatedDateTime` datetime NULL,
    CONSTRAINT `PK_EVouchers` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220326215000_EVouchersAdd', '6.0.3');

COMMIT;

START TRANSACTION;

CREATE TABLE `PurchaseEVouchers` (
    `id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `eVoucher_id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `buyType_id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `paymentMethod_id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `netAmount` decimal(65,30) NOT NULL,
    `promoCode` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `isUsed` int NOT NULL,
    `createdDateTime` datetime(6) NOT NULL,
    `updatedDateTime` datetime(6) NULL,
    CONSTRAINT `PK_PurchaseEVouchers` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220327052555_PurchaseEVoucherAdd', '6.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE `PurchaseEVouchers` MODIFY COLUMN `netAmount` int NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220327061628_PurchaseEVoucherUpdateNetAmountColumn', '6.0.3');

COMMIT;

START TRANSACTION;

CREATE TABLE `ItemPurchase` (
    `id` char(37) CHARACTER SET utf8mb4 NOT NULL,
    `item` nvarchar(200) NOT NULL,
    `promocode` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `totalamount` int NOT NULL,
    `userid` longtext CHARACTER SET utf8mb4 NULL,
    `createdDateTime` datetime NOT NULL,
    `updatedDateTime` datetime NULL,
    CONSTRAINT `PK_ItemPurchase` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220327092429_ItemPurchaseAdd', '6.0.3');

COMMIT;

