-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Waktu pembuatan: 09 Apr 2019 pada 07.00
-- Versi server: 5.7.23
-- Versi PHP: 5.6.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_ujikom`
--

DELIMITER $$
--
-- Prosedur
--
DROP PROCEDURE IF EXISTS `tampil_transaksi`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `tampil_transaksi` ()  BEGIN
SELECT *  FROM  transaksi_kredit;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `motor`
--

DROP TABLE IF EXISTS `motor`;
CREATE TABLE IF NOT EXISTS `motor` (
  `kd_motor` varchar(10) NOT NULL,
  `type` varchar(20) DEFAULT NULL,
  `merk` varchar(30) DEFAULT NULL,
  `harga` int(11) NOT NULL,
  `picture` longtext,
  PRIMARY KEY (`kd_motor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `motor`
--

INSERT INTO `motor` (`kd_motor`, `type`, `merk`, `harga`, `picture`) VALUES
('MTR00001', 'MIO Z', 'Mio', 10000000, 'Yamaha_Mio_L_1.jpg');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pelanggan`
--

DROP TABLE IF EXISTS `pelanggan`;
CREATE TABLE IF NOT EXISTS `pelanggan` (
  `kd_pelanggan` int(11) NOT NULL AUTO_INCREMENT,
  `nama_pelanggan` char(50) DEFAULT NULL,
  `no_ktp` int(20) NOT NULL,
  `alamat` varchar(100) DEFAULT NULL,
  `pekerjaan` char(50) DEFAULT NULL,
  PRIMARY KEY (`kd_pelanggan`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `pelanggan`
--

INSERT INTO `pelanggan` (`kd_pelanggan`, `nama_pelanggan`, `no_ktp`, `alamat`, `pekerjaan`) VALUES
(3, 'Aini', 12345, 'Jl. Golf', 'Siswa'),
(4, 'Yogi', 122212323, 'Jl. Golf No. 20', 'Programmer .NET');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pembayaran_cicilan`
--

DROP TABLE IF EXISTS `pembayaran_cicilan`;
CREATE TABLE IF NOT EXISTS `pembayaran_cicilan` (
  `no_bayar` varchar(10) NOT NULL,
  `tgl_bayar` datetime(6) NOT NULL,
  `bulan_bayar` int(2) NOT NULL,
  `nominal_bayar` int(11) NOT NULL,
  `sisa_cicilan` int(11) NOT NULL,
  `status_bayar` int(1) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `no_kredit` varchar(10) DEFAULT NULL,
  `denda` int(11) NOT NULL DEFAULT '0',
  `bulan_denda` int(2) NOT NULL,
  PRIMARY KEY (`no_bayar`),
  KEY `IX_pembayaran_cicilan_no_kredit` (`no_kredit`),
  KEY `IX_pembayaran_cicilan_user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `pembayaran_cicilan`
--

INSERT INTO `pembayaran_cicilan` (`no_bayar`, `tgl_bayar`, `bulan_bayar`, `nominal_bayar`, `sisa_cicilan`, `status_bayar`, `user_id`, `no_kredit`, `denda`, `bulan_denda`) VALUES
('TRS00001', '2019-05-04 21:58:12.452330', 1, 1435499, 10, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 130500, 4),
('TRS00002', '2019-05-04 21:59:06.263674', 2, 1304999, 9, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00003', '2019-05-05 09:48:24.057816', 3, 1304999, 8, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00004', '2019-05-05 10:24:22.914268', 4, 1304999, 7, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00005', '2019-05-05 10:24:35.306921', 5, 1304999, 6, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00006', '2019-05-05 10:24:43.811450', 6, 1304999, 5, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00007', '2019-05-05 10:24:53.061464', 7, 1304999, 4, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00008', '2019-05-05 10:25:15.907237', 8, 1304999, 3, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5),
('TRS00009', '2019-06-05 10:25:25.620254', 9, 1304999, 2, 1, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'KRD00001', 0, 5);

-- --------------------------------------------------------

--
-- Struktur dari tabel `petugas`
--

DROP TABLE IF EXISTS `petugas`;
CREATE TABLE IF NOT EXISTS `petugas` (
  `kd_petugas` int(11) NOT NULL AUTO_INCREMENT,
  `nama` char(50) DEFAULT NULL,
  `bagian` varchar(50) DEFAULT NULL,
  `keterangan` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`kd_petugas`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `petugas`
--

INSERT INTO `petugas` (`kd_petugas`, `nama`, `bagian`, `keterangan`) VALUES
(1, 'admin', 'admin', 'admin'),
(6, 'Chandra', 'Kasir', 'Kasir'),
(7, 'Torik Al', 'CSO', 'CSO'),
(8, 'Yandi Saefulloh', 'Sales', 'Sales'),
(9, 'admin', 'admin', 'admin'),
(10, 'admin', 'Admin', 'admin'),
(38, 'admin', 'admin', 'admin'),
(39, 'admin', 'admin', 'admin'),
(40, 'admin', 'admin', 'admin'),
(41, 'admin', 'admin', 'admin'),
(42, 'admin', 'admin', 'admin'),
(48, 'admin zein', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `roleclaims`
--

DROP TABLE IF EXISTS `roleclaims`;
CREATE TABLE IF NOT EXISTS `roleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_RoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE IF NOT EXISTS `roles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  `Discriminator` longtext NOT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `roles`
--

INSERT INTO `roles` (`Id`, `Name`, `ConcurrencyStamp`, `Discriminator`, `NormalizedName`) VALUES
('6638d67f-6a9c-4775-a95c-efedb749e354', 'kasir', '806102a1-ced4-4a56-9de3-c3cdd5891d3b', 'IdentityRole', 'KASIR'),
('854be0fc-d369-4efb-a9d8-329fbdf13383', 'admin', '4a8ffb4c-be3e-436f-ae15-62d521a9c13e', 'IdentityRole', 'ADMIN'),
('9a1fce3a-be2a-4483-9331-08fc1c711354', 'sales', '0a2a75fd-5f87-47fc-bb36-cb561c37201f', 'IdentityRole', 'SALES'),
('d432630d-a3b6-4afa-98d9-6fc28aea4a7f', 'cso', 'b2033586-b477-4ac4-bb9e-94c9a16e0f48', 'IdentityRole', 'CSO');

-- --------------------------------------------------------

--
-- Struktur dari tabel `site_setting`
--

DROP TABLE IF EXISTS `site_setting`;
CREATE TABLE IF NOT EXISTS `site_setting` (
  `id_setting` int(11) NOT NULL AUTO_INCREMENT,
  `dp_setting` float NOT NULL,
  `surat_surat_setting` float NOT NULL,
  `denda_setting` float NOT NULL,
  `bunga_setting` float NOT NULL,
  PRIMARY KEY (`id_setting`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `site_setting`
--

INSERT INTO `site_setting` (`id_setting`, `dp_setting`, `surat_surat_setting`, `denda_setting`, `bunga_setting`) VALUES
(1, 0.3, 50000, 0.1, 0.1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi_kredit`
--

DROP TABLE IF EXISTS `transaksi_kredit`;
CREATE TABLE IF NOT EXISTS `transaksi_kredit` (
  `no_kredit` varchar(10) NOT NULL,
  `kd_motor` varchar(10) DEFAULT NULL,
  `kd_pelanggan` int(11) NOT NULL,
  `dp` int(11) NOT NULL,
  `tenor` int(11) NOT NULL,
  `bunga` int(11) NOT NULL,
  `cicilan` int(11) NOT NULL,
  `user_id` varchar(50) DEFAULT NULL,
  `status_verif` int(1) NOT NULL,
  `tgl_verif` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`no_kredit`),
  KEY `IX_transaksi_kredit_kd_motor` (`kd_motor`),
  KEY `IX_transaksi_kredit_kd_pelanggan` (`kd_pelanggan`),
  KEY `IX_transaksi_kredit_user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `transaksi_kredit`
--

INSERT INTO `transaksi_kredit` (`no_kredit`, `kd_motor`, `kd_pelanggan`, `dp`, `tenor`, `bunga`, `cicilan`, `user_id`, `status_verif`, `tgl_verif`) VALUES
('KRD00001', 'MTR00001', 4, 3000000, 11, 118636, 1304999, 'ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 1, '2019-05-05 13:43:25.271396');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `Discriminator` longtext NOT NULL,
  `kd_petugas` int(11) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `IX_user_kd_petugas` (`kd_petugas`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`Id`, `UserName`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `Discriminator`, `kd_petugas`, `NormalizedUserName`, `TwoFactorEnabled`) VALUES
('0f862c7f-3108-4834-86ea-508b0020a1a7', 'csotorik', 'AQAAAAEAACcQAAAAEADldEAdBAX0l33I7WyNyLUQHI6r/+25XQ2KbVRvBDRwms214qOTpzLLFEmQ/PH0sw==', '3eb0d34f-e404-436e-aced-9409bf449f83', 'd3a8c03f-f9e2-4f7b-a1d8-772deb2e1c7c', 'ApplicationUser', 7, 'CSOTORIK', b'0'),
('36e5b0ed-db51-467f-80fc-d80219f8a2d3', 'salesyandi', 'AQAAAAEAACcQAAAAEH9nQHowdYRUfJF2Zq5divhlYLUwc6BdTtV/CxoycCo3gLjVRXXW2A9cQxtLfGukjA==', '90d9a6a7-ae44-4f88-9fb6-bf692e0acbfa', '7893d5df-0c4c-4b1a-898a-6b859771d904', 'ApplicationUser', 8, 'SALESYANDI', b'0'),
('574c1334-fa49-466c-ab2d-c3257337b661', 'kasirchand', 'AQAAAAEAACcQAAAAEDeXhwDEvfdL2qB/mcOGSGYqDhPAjElFBDw/w/bp8TmPiL4NbPPuBmqFisy+EQDO1A==', '47bb8ab3-1a63-448c-b7c1-c6af365102ce', 'a5d875ca-cb54-4b11-8e45-2968708cca38', 'ApplicationUser', 6, 'KASIRCHAND', b'0'),
('ddc47979-9616-4e7b-9ff7-ea18b8016b0b', 'admin', 'AQAAAAEAACcQAAAAELDrDWxLLHfeN5sodcAqjU7JDxPqlCTwCK92THCWmP6fnJo2F2ehScxp1T7ukvnGPA==', '65711a03-b062-47d4-b683-8d326d0b80e3', 'bbec1cdf-df92-4690-adac-3bc8da407fcc', 'ApplicationUser', 1, 'ADMIN', b'0'),
('e51def02-b188-4446-a9e1-a3af399142cd', 'adminzein', 'AQAAAAEAACcQAAAAEIG1LaiIRKGX12Kw1FHMNOmEd/H9ocn4Vzn6iPn3u7GaADnq53z+RiUyfmJjPdwhIg==', '578664a9-bf3e-472c-876f-5780d5929a6a', 'c10d40ff-1e7c-4ff8-ad82-bd6bc0fc0ac7', 'ApplicationUser', 48, 'ADMINZEIN', b'0');

-- --------------------------------------------------------

--
-- Struktur dari tabel `userclaims`
--

DROP TABLE IF EXISTS `userclaims`;
CREATE TABLE IF NOT EXISTS `userclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_UserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `userlogins`
--

DROP TABLE IF EXISTS `userlogins`;
CREATE TABLE IF NOT EXISTS `userlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_UserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `userroles`
--

DROP TABLE IF EXISTS `userroles`;
CREATE TABLE IF NOT EXISTS `userroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_UserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `userroles`
--

INSERT INTO `userroles` (`UserId`, `RoleId`) VALUES
('574c1334-fa49-466c-ab2d-c3257337b661', '6638d67f-6a9c-4775-a95c-efedb749e354'),
('ddc47979-9616-4e7b-9ff7-ea18b8016b0b', '854be0fc-d369-4efb-a9d8-329fbdf13383'),
('e51def02-b188-4446-a9e1-a3af399142cd', '854be0fc-d369-4efb-a9d8-329fbdf13383'),
('36e5b0ed-db51-467f-80fc-d80219f8a2d3', '9a1fce3a-be2a-4483-9331-08fc1c711354'),
('0f862c7f-3108-4834-86ea-508b0020a1a7', 'd432630d-a3b6-4afa-98d9-6fc28aea4a7f');

-- --------------------------------------------------------

--
-- Struktur dari tabel `usertokens`
--

DROP TABLE IF EXISTS `usertokens`;
CREATE TABLE IF NOT EXISTS `usertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `usertokens`
--

INSERT INTO `usertokens` (`UserId`, `LoginProvider`, `Name`, `Value`) VALUES
('ddc47979-9616-4e7b-9ff7-ea18b8016b0b', '[AspNetUserStore]', 'AuthenticatorKey', 'OHO3HVP46HFCABSRXWX3HPTXZH3SK53L');

-- --------------------------------------------------------

--
-- Struktur dari tabel `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20190401072830_create first table', '2.1.0-rtm-30799'),
('20190401074920_add foreign key petugas_id', '2.1.0-rtm-30799'),
('20190401080000_add all foreign key', '2.1.0-rtm-30799'),
('20190401080635_add user foreign key', '2.1.0-rtm-30799'),
('20190401080935_add field denda', '2.1.0-rtm-30799'),
('20190401144816_remove unnecessary field', '2.1.0-rtm-30799'),
('20190401145114_remove unnecessary field 2', '2.1.0-rtm-30799'),
('20190401145256_remove unnecessary field 3', '2.1.0-rtm-30799'),
('20190401150513_remove unnecessary field 4', '2.1.0-rtm-30799'),
('20190401153736_new revert', '2.1.0-rtm-30799'),
('20190402073629_update field motor', '2.1.0-rtm-30799'),
('20190402155430_add site setting', '2.1.0-rtm-30799'),
('20190403051709_add null for date verif', '2.1.0-rtm-30799'),
('20190403131133_add bulan denda', '2.1.0-rtm-30799'),
('20190403133805_edit bulan denda', '2.1.0-rtm-30799');

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `pembayaran_cicilan`
--
ALTER TABLE `pembayaran_cicilan`
  ADD CONSTRAINT `FK_pembayaran_cicilan_transaksi_kredit_no_kredit` FOREIGN KEY (`no_kredit`) REFERENCES `transaksi_kredit` (`no_kredit`) ON DELETE NO ACTION,
  ADD CONSTRAINT `FK_pembayaran_cicilan_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`Id`) ON DELETE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `roleclaims`
--
ALTER TABLE `roleclaims`
  ADD CONSTRAINT `FK_RoleClaims_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `transaksi_kredit`
--
ALTER TABLE `transaksi_kredit`
  ADD CONSTRAINT `FK_transaksi_kredit_motor_kd_motor` FOREIGN KEY (`kd_motor`) REFERENCES `motor` (`kd_motor`) ON DELETE NO ACTION,
  ADD CONSTRAINT `FK_transaksi_kredit_pelanggan_kd_pelanggan` FOREIGN KEY (`kd_pelanggan`) REFERENCES `pelanggan` (`kd_pelanggan`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_transaksi_kredit_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`Id`) ON DELETE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `FK_user_petugas_kd_petugas` FOREIGN KEY (`kd_petugas`) REFERENCES `petugas` (`kd_petugas`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `userclaims`
--
ALTER TABLE `userclaims`
  ADD CONSTRAINT `FK_UserClaims_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `userlogins`
--
ALTER TABLE `userlogins`
  ADD CONSTRAINT `FK_UserLogins_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `FK_UserRoles_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UserRoles_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `usertokens`
--
ALTER TABLE `usertokens`
  ADD CONSTRAINT `FK_UserTokens_user_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
