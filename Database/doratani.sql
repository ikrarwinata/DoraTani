-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: 01 Mar 2021 pada 19.23
-- Versi Server: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `doratani`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `akun_pengguna`
--

DROP TABLE IF EXISTS `akun_pengguna`;
CREATE TABLE IF NOT EXISTS `akun_pengguna` (
  `username` varchar(25) NOT NULL,
  `password` varchar(100) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `level` enum('kasir','admin','owner') NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `akun_pengguna`
--

INSERT INTO `akun_pengguna` (`username`, `password`, `nama`, `level`) VALUES
('admin', '21232f297a57a5a743894a0e4a801fc3', 'admin', 'admin'),
('kasir', 'c7911af3adbd12a035b289556d96470a', 'kasir', 'kasir'),
('owner', '72122ce96bfec66e2396d2e25225d70a', 'owner', 'owner');

-- --------------------------------------------------------

--
-- Struktur dari tabel `barang_masuk`
--

DROP TABLE IF EXISTS `barang_masuk`;
CREATE TABLE IF NOT EXISTS `barang_masuk` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kode_barang` varchar(25) NOT NULL,
  `tanggal` int(2) NOT NULL,
  `bulan` int(2) NOT NULL,
  `tahun` int(4) NOT NULL,
  `qty` int(11) NOT NULL,
  `kode_suplier` varchar(25) NOT NULL,
  `users` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `barang_masuk`
--

INSERT INTO `barang_masuk` (`id`, `kode_barang`, `tanggal`, `bulan`, `tahun`, `qty`, `kode_suplier`, `users`) VALUES
(1, 'PRDK-2021-0000000001', 16, 2, 2021, 100, 'SPL-2021-0000000001', 'admin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `detail_transaksi`
--

DROP TABLE IF EXISTS `detail_transaksi`;
CREATE TABLE IF NOT EXISTS `detail_transaksi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kode_transaksi` varchar(25) NOT NULL,
  `qty` int(11) NOT NULL,
  `kode_barang` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `detail_transaksi`
--

INSERT INTO `detail_transaksi` (`id`, `kode_transaksi`, `qty`, `kode_barang`) VALUES
(1, 'TRN-2021-0000000001', 2, 'PRDK-2021-0000000001'),
(2, 'TRN-2021-0000000002', 1, 'PRDK-2021-0000000001'),
(3, 'TRN-2021-0000000003', 1, 'PRDK-2021-0000000001');

-- --------------------------------------------------------

--
-- Struktur dari tabel `master_barang`
--

DROP TABLE IF EXISTS `master_barang`;
CREATE TABLE IF NOT EXISTS `master_barang` (
  `kode` varchar(25) NOT NULL,
  `barcode` varchar(25) DEFAULT NULL,
  `nama` varchar(200) NOT NULL,
  `kategori` varchar(100) NOT NULL,
  `satuan` varchar(100) NOT NULL,
  `harga` float NOT NULL DEFAULT '0',
  `kadaluarsa` varchar(15) NOT NULL,
  `stok` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`kode`),
  UNIQUE KEY `barcode` (`barcode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `master_barang`
--

INSERT INTO `master_barang` (`kode`, `barcode`, `nama`, `kategori`, `satuan`, `harga`, `kadaluarsa`, `stok`) VALUES
('PRDK-2021-0000000001', '8992745140573', 'HIT Mat elektrik original', 'Obat nyamuk', 'Pcs', 4500, '1645833600000', 96);

-- --------------------------------------------------------

--
-- Stand-in structure for view `reportbm`
-- (Lihat di bawah untuk tampilan aktual)
--
DROP VIEW IF EXISTS `reportbm`;
CREATE TABLE IF NOT EXISTS `reportbm` (
`kode_barang` varchar(25)
,`tanggal` varchar(35)
,`qty` int(11)
,`nama_barang` varchar(200)
,`kode_suplier` varchar(25)
,`nama_suplier` varchar(100)
,`users` varchar(25)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `struk`
-- (Lihat di bawah untuk tampilan aktual)
--
DROP VIEW IF EXISTS `struk`;
CREATE TABLE IF NOT EXISTS `struk` (
`kode` varchar(25)
,`timestamps` varchar(100)
,`nama_barang` varchar(200)
,`qty` int(11)
,`harga` float
,`subtotal` double
,`total` float
,`bayar` float
,`kembali` float
,`kasir` varchar(25)
,`nama_kasir` varchar(50)
);

-- --------------------------------------------------------

--
-- Struktur dari tabel `suplier`
--

DROP TABLE IF EXISTS `suplier`;
CREATE TABLE IF NOT EXISTS `suplier` (
  `kode` varchar(25) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `kota` varchar(25) NOT NULL,
  `telp` varchar(20) DEFAULT NULL,
  `alamat` text,
  `keterangan` text,
  PRIMARY KEY (`kode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `suplier`
--

INSERT INTO `suplier` (`kode`, `nama`, `kota`, `telp`, `alamat`, `keterangan`) VALUES
('SPL-2021-0000000001', 'PT.ababsbas', 'palembang', '90909090', 'kalsjdklajsdalkj', 'klajskdlasjdklasjd');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

DROP TABLE IF EXISTS `transaksi`;
CREATE TABLE IF NOT EXISTS `transaksi` (
  `kode` varchar(25) NOT NULL,
  `timestamps` varchar(100) NOT NULL,
  `total` float NOT NULL,
  `bayar` float NOT NULL,
  `kembali` float NOT NULL DEFAULT '0',
  `kasir` varchar(25) NOT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`kode`, `timestamps`, `total`, `bayar`, `kembali`, `kasir`) VALUES
('TRN-2021-0000000001', '1613489070851', 9000, 10000, 1000, 'admin'),
('TRN-2021-0000000002', '1613489152994', 4500, 5000, 500, 'admin'),
('TRN-2021-0000000003', '1613489262716', 4500, 5000, 500, 'admin');

-- --------------------------------------------------------

--
-- Stand-in structure for view `transaksi_report`
-- (Lihat di bawah untuk tampilan aktual)
--
DROP VIEW IF EXISTS `transaksi_report`;
CREATE TABLE IF NOT EXISTS `transaksi_report` (
`kode` varchar(25)
,`timestamps` varchar(100)
,`total` float
,`bayar` float
,`kembali` float
,`kasir` varchar(25)
,`qty` decimal(32,0)
,`nama_kasir` varchar(50)
);

-- --------------------------------------------------------

--
-- Struktur untuk view `reportbm`
--
DROP TABLE IF EXISTS `reportbm`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `reportbm`  AS  select `a`.`kode_barang` AS `kode_barang`,concat(`a`.`tanggal`,'-',`a`.`bulan`,'-',`a`.`tahun`) AS `tanggal`,`a`.`qty` AS `qty`,`b`.`nama` AS `nama_barang`,`c`.`kode` AS `kode_suplier`,`c`.`nama` AS `nama_suplier`,`a`.`users` AS `users` from ((`barang_masuk` `a` left join `master_barang` `b` on((`a`.`kode_barang` = `b`.`kode`))) left join `suplier` `c` on((`a`.`kode_suplier` = `c`.`kode`))) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `struk`
--
DROP TABLE IF EXISTS `struk`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `struk`  AS  (select `a`.`kode` AS `kode`,`a`.`timestamps` AS `timestamps`,`c`.`nama` AS `nama_barang`,`b`.`qty` AS `qty`,`c`.`harga` AS `harga`,(`b`.`qty` * `c`.`harga`) AS `subtotal`,`a`.`total` AS `total`,`a`.`bayar` AS `bayar`,`a`.`kembali` AS `kembali`,`a`.`kasir` AS `kasir`,`d`.`nama` AS `nama_kasir` from (((`transaksi` `a` join `detail_transaksi` `b` on((`a`.`kode` = `b`.`kode_transaksi`))) join `master_barang` `c` on((`b`.`kode_barang` = `c`.`kode`))) left join `akun_pengguna` `d` on((`a`.`kasir` = `d`.`username`)))) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `transaksi_report`
--
DROP TABLE IF EXISTS `transaksi_report`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `transaksi_report`  AS  select `a`.`kode` AS `kode`,`a`.`timestamps` AS `timestamps`,`a`.`total` AS `total`,`a`.`bayar` AS `bayar`,`a`.`kembali` AS `kembali`,`a`.`kasir` AS `kasir`,sum(`b`.`qty`) AS `qty`,`c`.`nama` AS `nama_kasir` from ((`transaksi` `a` left join `detail_transaksi` `b` on((`a`.`kode` = `b`.`kode_transaksi`))) left join `akun_pengguna` `c` on((`a`.`kasir` = `c`.`username`))) group by `a`.`kode` order by `a`.`timestamps` ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
