use Milk
go

INSERT INTO Country (CountryID, CountryName, Image, [Delete]) VALUES 
(1, N'Hoa Kỳ', 'https://media.istockphoto.com/id/1258164837/photo/bright-american-flag-waving-in-the-wind-with-vibrant-red-white-and-blue-colors-lit-by-the-sun.jpg?s=612x612&w=0&k=20&c=oJFY7AUvwp5NiCZ7vXWO1mcnfsOrSH63aznCqyzB2Ow=', 1),  
(2, N'Thụy Điển', 'https://cdn.slidesharecdn.com/ss_thumbnails/swedenanditspoliticalsystem-101019132146-phpapp02-thumbnail.jpg?width=640&height=640&fit=bounds', 1), 
(3, N'Pháp', 'https://eurotravel.com.vn/wp-content/uploads/2023/05/quoc-ky-nuoc-phap-hien-nay.jpg', 1), 
(4, N'Nhật Bản', 'https://namchauims.com/wp-content/uploads/2022/03/la-co-nhat-ban.jpg', 1), 
(5, N'Việt Nam', 'https://img4.thuthuatphanmem.vn/uploads/2019/11/19/hinh-nen-la-co-viet-nam_021823653.png', 1), 
(6, N'Singapore', 'https://toursingapore.vn/wp-content/uploads/2022/01/quoc-ky-singapore-3.jpg', 1), 
(7, N'Úc', 'https://static.ffx.io/images/$zoom_1%2C$multiply_1%2C$ratio_1.777778%2C$width_1992%2C$x_8%2C$y_148/t_crop_custom/w_768/t_sharpen%2Cq_auto%2Cf_auto/50ea96b1e07e1c678116dea794f24a7338ca37ab', 1), 
(8, N'Thụy Sĩ', 'https://eurotravel.com.vn/wp-content/uploads/2023/05/quoc-ky-ngay-nay-cua-thuy-si.jpg', 1), 
(9, N'Hàn Quốc', 'https://thietbidoandoi.com/wp-content/uploads/2022/04/L%C3%A1-c%E1%BB%9D-H%C3%A0n-4.jpg', 1), 
(10, N'Hà Lan', 'https://www.2holland.nl/wp-content/uploads/2017/05/Foto-02-04-17-13-49-05.jpg', 1), 
(11, N'New Zealand', 'https://th.bing.com/th/id/OIP.8l4kJefdRxMwpYjLPtmqawHaGK?w=626&h=521&rs=1&pid=ImgDetMain', 1);


INSERT INTO Company (CompanyID, CompanyName, CountryID, Image, [Delete]) VALUES 
(1, N'Abbott Laboratories', 1, 'https://www.sobrato.com/wp-content/uploads/2018/12/SBTO_071_12_4451_Great_America.jpg', 1), 
(2, N'Alpha Grow Company', 1, 'https://media-cdn-v2.laodong.vn/Storage/NewsPortal/2020/12/11/861523/Anh-2-1.jpg', 1), 
(3, N'Meiji Co', 4, 'https://cdn.tgdd.vn//News/1438381//sua-meiji-cua-nuoc-nao-co-tot-khong-nhung-dong-1-845x450.jpg', 1), 
(4, N'Abbott Manufacturing Singapore Private Limited', 6, 'https://cdn.tgdd.vn/Files/2017/06/07/990395/gioi-thieu-tap-doan-abbott-1_800x400.jpg', 1), 
(5, N'Vinamilk', 5, 'https://nqs.1cdn.vn/thumbs/720x480/2022/01/30/20210811091557-3220.png', 1), 
(6, N'Wakodo', 4, 'https://kienthuckinhte.vn/uploads/vnm.JPG', 1), 
(7, N'Royal Ausnz', 7, 'https://lavenderstudio.com.vn/wp-content/uploads/2019/02/word-image-4.png', 1), 
(8, N'Morinaga Milk Industry', 4, 'https://morinaga-nf.com.vn/wp-content/uploads/2024/04/1K0A1340-1-2-scaled.jpg', 1), 
(9, N'FrieslandCampina', 10, 'https://lh4.googleusercontent.com/proxy/r08XoC9W9gx0dltLMaW01ftHA2vpFzt4JXSqWpIYCki3JWRE3DpaVlEEgXBKtZ4rn--ZrCfKUpe69-gz', 1), 
(10, N'VitaDairy', 5, 'https://vitadairy.vn/s/images/page/corp-information/news6.jpg', 1), 
(11, N'Anmum', 11, 'https://quachobe.vn/wp-content/uploads/2020/03/Review-s%E1%BB%AFa-b%E1%BA%A7u-anmum-1.png', 1), 
(12, N'Mead Johnson Nutrition', 1, 'https://cdn.tgdd.vn/Files/2017/08/01/1009013/gioi-thieu-cong-ty-mead-johnson-nutrition-1_800x427.jpg', 1), 
(13, N'Namyang Dairy Products', 9, 'https://lh5.googleusercontent.com/proxy/rRa_Z8wjo3A9Tq4UTRgS1xk7xNrc5fc0B4Kq3sLxhVaNkHtikJ7WwS_um5UwuvqQzqUyeuXW1ikMnEm-PDC4aev1k2XtDfVLDwu4LEvSi5bys9Glh4TDPfLZRESHDAv34ohOh5RiEppV', 1), 
(14, N'HOCHDORF Swiss Nutrition', 8, 'https://www.hochdorf.com/fileadmin/_processed_/6/5/csm_Gebaeude-Sulgen-Drohnenaufnahme_Nah_bearb_7ca5a387a4.jpeg', 1), 
(15, N'Nutricare', 5, 'https://file1.dangcongsan.vn/data/0/images/2022/01/07/minhphuong/bc.jpg', 1),  
(16, N'Eneright Nutrition', 5, 'https://gmp.com.vn/images/project/2021/06/28/large/nha-may-sua-eneright-tieu-chuan-gmp-haccp-nho_1624868795.png', 1), 
(17, N'Nestlé', 8, 'https://cdn.tgdd.vn/Files/2017/06/09/991025/gioi-thieu-ve-tap-doan-nestle-11_800x400.jpg', 1),
(18, N'Aiwado', 4, 'https://aiwado.com/image/catalog/Hoi%20thao/Aiwado-hoi-thao-hai-phong-2.jpg', 1), 
(19, N'TGD', 5, 'https://media.sohuutritue.net.vn/files/nguyenhue/2022/11/04/t1-1342.jpg', 1), 
(20, N'Royal Friesland Campina', 10, 'https://www.wur.nl/upload/13e3c201-ddb0-4521-8f55-6ad1ec92b3b0_frieslandcampinagebouw.png', 1), 
(21, N'Glico', 4, 'https://suachobeyeu.vn/upload/images/thuong-hieu-glico-2.jpg', 1), 
(22, N'Danone', 3, 'https://bestplus.vn/Userfiles/Upload/images/Danone%201.jpg', 1), 
(23, N'Franci Việt Nam', 5, 'https://vodac.com.vn/wp-content/uploads/2019/12/Sequence-01.00_05_01_07.Still018.jpg', 1), 
(24, N'Nutifood', 2, 'https://tst-vn.com/wp-content/uploads/2021/01/unnamed.jpg', 1),  
(25, N'Nutriking', 5, 'https://akme.com.vn/uploads/plugin/product_items/11/nutriking.jpg', 1),
(26, N'Nutricia', 10, 'https://imgs.vietnamnet.vn/Images/2011/08/25/14/20110825141205_vinamilk2.jpg', 1);



INSERT INTO BrandMilk (BrandMilkID, BrandName, CompanyID, Image, [Delete])
VALUES
(1, N'Similac', 1, 'https://cdn.tgdd.vn//News/0//logoSimilac-845x500.jpg', 1),
(2, N'Alpha Grow', 2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmho_oDtGVH-iBsWaKm6Z1kjzWt_K9944BKQ&s', 1),
(3, N'Meiji', 3, 'https://www.meiji.com.vn/wp-content/uploads/2022/11/Banner-About-meiji-02-2.png', 1),
(4, N'Pediasure', 4, 'https://static.wikia.nocookie.net/logopedia/images/3/38/PediaSure_logo.jpg/revision/latest?cb=20130506163616', 1),
(5, N'Vinamilk', 5, 'https://upload.wikimedia.org/wikipedia/vi/0/06/Vinamilk_logo.jpg', 1),
(6, N'Wakodo', 6, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQD1_vV8UdeKVeSsqCaQuR9tldvC9CfE8gEQg&s', 1),
(7, N'Royal Ausnz', 7, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2Hooi_ascZdGYoYaJoIcUygsCs8lSVV1V5w&s', 1),
(8, N'Morinaga', 8, 'https://images.crunchbase.com/image/upload/c_pad,h_256,w_256,f_auto,q_auto:eco,dpr_1/oduut0tpifdoxpetap6q', 1),
(9, N'FrieslandCampina', 9, 'https://banner2.cleanpng.com/20180525/tc/kisspng-frieslandcampina-middle-east-friesland-foods-milk-dairy-logo-5b0896d7695940.0395406115272895594315.jpg', 1),
(10, N'ColosBaby', 10, 'https://cdn-v2.kidsplaza.vn/media/catalog/product/s/u/sua-bot-colosbaby-iq-gold-1-800g-1-2y-5.jpg', 1),
(11, N'Anmum', 11, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTvXWej-fvdp3BBgVL5n_B9RU_ET8kwS5S0A&s', 1),
(12, N'Enfamama', 12, 'https://s1.tryandreview.com/uploads/images/brands/brand_logo_033vwx97sw7h.png?v141', 1),
(13, N'Namyang', 13, 'https://suachobeyeu.vn/upload/images/sua-cho-be-namyang-han-quoc-9.jpg', 1),
(14, N'Bimbosan', 14, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRwyqg8It9sXACDnlihMjMVBjRBw-lf-8XTAg&s', 1),
(15, N'Metamom', 15, 'https://nutricare.com.vn/wp-content/uploads/2021/11/salekit_Metamom-1.png', 1),
(16, N'Nestlé', 17, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRukAVGGhbwzKk0mcb1R4rdvb-8xkBvXGAazg&s', 1),
(17, N'Merrikiz', 16, 'https://filebroker-cdn.lazada.vn/kf/Sc0aac5e7ee1b43ba8ad0500bbdcaba7fS.jpg', 1),
(18, N'Oggi', 10, 'https://huongxuashop.com/oggy-tang-can-nhanh-ngua-tao-bon.png', 1),
(19, N'Nuti IQ', 24, 'https://nutifood.com.vn/san-pham/sua-bot-tre-em/nuti-iq-gold/assets/images/products/benefit-title.png', 1),
(20, N'Fortimel', 26, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTcMqN3l2et2fLNw60rg4ikXJy2tg97hTW3w&s', 1),
(21, N'Milky AuZ', 19, 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lv5xaysrkbuha9', 1),
(22, N'Kazu Mom', 18, 'https://cdn.chanhtuoi.com/uploads/2022/03/sua-kazu-gold-4-2-1.jpg', 1),
(23, N'Endolac', 16, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTl3PWUJxIS3BMTPKjBfG6M1SJb4J8VNRSD0Q&s', 1),
(24, N'Nutricare', 15, 'https://nutricare.com.vn/wp-content/uploads/2021/11/Nutricare-cai-tien-logo-san-sang-cho-buoc-chuyen-minh-an-tuong-trong-tuong-lai-3.jpg', 1),
(25, N'Nutriking', 25, 'https://redirector.icheck.vn/NjYzODYyMzE2NjY0MzYzMjY2NjE2MjMwMzIzNTM5NjQzNTM0MzAzNjY2MzE2NjY0NjEzMzM2MzAzOTYxMzU2NjYxMzY2NjM4NjE2NjYyMzIzODY2MzAzNTYyMzUzODM2NjUzNDY0MzAzNDM4MzQzMTYyMzk2NDM0MzY2NjYyNjI2MzY0NjQ2NjY0NjMzODYxN2M3MDY4NmY3NDZmN2M2ZjcyNjk2NzY5NmU2MTZjN2MzMTM3MzEzOTMwMzIzNTM5MzMzMzdjNmE3MDY3N2M2NjY5NzQ-', 1),
(26, N'Friso', 20, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHyDpGw_HhIXh5EI8JaKLAvUn6ryVMTS7U0Q&s', 1),
(27, N'Glico', 21, 'https://suachobeyeu.vn/upload/images/logo-glico.jpg', 1),
(28, N'NAN', 17, 'https://www.nestle.com.vn/sites/g/files/pydnoa216/files/nan-logo-round_0.png', 1),
(29, N'Aptamil', 22, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIVDhaPE36P4_yt_YkuPj2VrkfhQ7GX02R7g&s', 1),
(30, N'Franci Việt Nam', 23, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIn8ylt9TNQspys07LpG5JTl2hYFRUFSxrNA&s', 1),
(31, N'Nutifood', 24, 'https://www.moby.com.vn/data/ck/images/review%20s%E1%BB%AFa%20Nutifood%20c%C3%B3%20t%E1%BB%91t%20kh%C3%B4ng%20-3.png', 1);


INSERT INTO Admin (AdminID, Username, Password, Role, [Delete])
VALUES 
(1, N'Staff1@gmail.com', N'1', N'Staff', 1),
(2, N'Staff2@gmail.com', N'2', N'Staff', 1),
(3, N'Staff3@gmail.com', N'3', N'Staff', 1),
(4, N'Staff4@gmail.com', N'4', N'Staff', 1),
(5, N'Staff5@gmail.com', N'staff123', N'Staff', 1),
(6, N'bao@gmail.com', N'admin123', N'Admin', 1);


INSERT INTO Customer (CustomerID, CustomerName, Email, Password, Phone, [Delete]) VALUES
(1, N'Nguyễn Văn A', N'nguyenvana@gmail.com', N'password1', '1234567890', 1),
(2, N'Nguyễn Văn B', N'nguyenvanb@gmail.com', N'password2', '2345678901', 1),
(3, N'Nguyễn Văn C', N'nguyenvanc@gmail.com', N'password3', '3456789012', 1),
(4, N'Nguyễn Văn D', N'nguyenvand@gmail.com', N'password4', '4567890123', 1),
(5, N'Nguyễn Văn E', N'nguyenvane@gmail.com', N'password5', '5678901234', 1);


INSERT INTO Storage (StorageID, StorageName, [Delete])
VALUES 
(1, N'Hà Nội', 1),
(2, N'TP Hồ Chí Minh', 1),
(3, N'Đà Nẵng', 1),
(4, N'Hải Phòng', 1),
(5, N'Bình Dương', 1);

INSERT INTO DeliveryMan (DeliveryManID, DeliveryName, DeliveryStatus, PhoneNumber, StorageID, StorageName, [Delete])
VALUES 
(1, N'Trần Văn A', N'Sẵn sàng', '1234567890', 1, N'Hà Nội', 1),
(2, N'Trần Văn B', N'Bận', '2234567891', 1, N'Hà Nội', 1),
(3, N'Trần Văn C', N'Sẵn sàng', '3234567892', 2, N'TP Hồ Chí Minh', 1),
(4, N'Trần Văn D', N'Bận', '4234567893', 2, N'TP Hồ Chí Minh', 1),
(5, N'Trần Văn E', N'Sẵn sàng', '5234567894', 3, N'Đà Nẵng', 1),
(6, N'Trần Văn F', N'Bận', '6234567895', 3, N'Đà Nẵng', 1),
(7, N'Trần Văn G', N'Sẵn sàng', '7234567896', 4, N'Hải Phòng', 1),
(8, N'Trần Văn H', N'Bận', '8234567897', 4, N'Hải Phòng', 1),
(9, N'Trần Văn I', N'Sẵn sàng', '9234567898', 5, N'Bình Dương', 1),
(10, N'Trần Văn J', N'Bận', '1234567899', 5, N'Bình Dương', 1);


INSERT INTO ProductItem (ProductItemID, Benefit, Description, Image1, Image2, Image3, ItemName, Price, Weight, BrandMilkID, Baby, Mama, BrandName, CountryName, CompanyName, Discount, SoldQuantity, StockQuantity, [Delete])
VALUES
(
    1,
    N'Cung cấp dinh dưỡng hoàn chỉnh cho trẻ sơ sinh',
    N'Similac Advance là một sản phẩm sữa công thức hoàn chỉnh về dinh dưỡng, dựa trên sữa bò và có bổ sung sắt, cung cấp dưỡng chất cần thiết cho trẻ sơ sinh trong năm đầu đời.',
    N'https://mebeplaza.com/wp-content/uploads/2020/08/similac-advance-1.13kg.jpg',
    N'https://d31f1ehqijlcua.cloudfront.net/n/d/7/2/6/d7262a376571a8d5246180ea713156e25e79631a_BabyFormula_443699_04.jpg',
    N'https://d31f1ehqijlcua.cloudfront.net/n/6/0/2/0/6020fad23733fe9a475bf96af8f2ee080cc390f8_BabyFormula_443699_05.jpg',
    N'Similac Advance',
    650000.00,
    1.13,
    1,
    N'0-1 tuổi',
    N'',
    N'Similac',
    N'Hoa Kỳ',
    N'Abbott Laboratories',
	10,
	500,
	250,
	1
),
(
    2,
    N'Hỗ trợ phát triển não bộ và sức khỏe miễn dịch',
    N'Alpha Grow A+ NeuroPro là sữa công thức hoàn chỉnh về dinh dưỡng với NeuroPro, một sự pha trộn các chất dinh dưỡng cho sự phát triển não bộ, cùng với các vitamin và khoáng chất thiết yếu khác cho sự phát triển tổng thể và hỗ trợ miễn dịch.',
    N'https://th.bing.com/th/id/OIP.6m4wJY2BlBLz_Mtkrw_qpgAAAA?rs=1&pid=ImgDetMain',
    N'https://cf.shopee.vn/file/e7911dec63b2f77ac319ce63ce85d534_tn',
    N'https://1source-upstream.s3.us-west-1.amazonaws.com/product_photo/449659_back_1618388104.png',
    N'Alpha Grow A+ NeuroPro',
    549000.00,
    830,
    2,
    N'1-3 tuổi',
    N'',
    N'Alpha Grow',
    N'Hoa Kỳ',
    N'Alpha Grow Company',
	10,
	700,
	530,
	1
),
(
    3,
    N'Hỗ trợ dinh dưỡng và phát triển cho trẻ sơ sinh',
    N'Sữa công thức Meiji 0-1 tuổi là sản phẩm sữa công thức hoàn chỉnh về dinh dưỡng, được thiết kế dành cho trẻ từ 0 đến 12 tháng tuổi. Sản phẩm cung cấp các dưỡng chất cần thiết cho sự phát triển và tăng trưởng của trẻ.',
    N'https://cdn1.concung.com/2021/04/27426-72037/meiji-infant-formula-800g-0-12-thang.jpg',
    N'https://bizweb.dktcdn.net/thumb/1024x1024/100/416/540/products/ffffffffffffff.jpg?v=1694137912743',
    N'https://bizweb.dktcdn.net/thumb/large/100/416/540/products/8888888.jpg?v=1694138052163',
    N'Meiji 0-1 years old Infant Formula',
    529000.00,
    800,
    3,
    N'0-1 tuổi',
    N'',
    N'Meiji',
    N'Nhật Bản',
    N'Meiji Co',
	20,
	680,
	500,
	1
),
(
    4,
    N'Hỗ trợ dinh dưỡng cho trẻ từ 1 đến 10 tuổi',
    N'Abbott Pediasure hương vị vani, bổ sung dinh dưỡng 1.6kg (1-10 tuổi) là một sản phẩm bổ sung dinh dưỡng dành cho trẻ từ 1 đến 10 tuổi. Không chứa gluten và rất ít lactose, phù hợp với trẻ không dung nạp lactose. Không dành cho trẻ dưới 1 tuổi trừ khi có chỉ định của bác sĩ. Hướng dẫn sử dụng: đổ 190 ml nước đun sôi để nguội (khoảng 37°C) vào ly, từ từ thêm 5 muỗng bột Pediasure đầy mặt khi khuấy cho đến khi tan hoàn toàn.',
    N'https://www.family.abbott/my-en/pediasure/products/pediasure-vanilla/_jcr_content/root/container/columncontrol_copy/tab_item_no_0/mediacarousel/item_1653228436183_c.coreimg.png/1669711037458/product-detail-component-pds-vanila.png',
    N'https://n3.sdlcdn.com/imgs/j/r/e/PediaSure-Infant-Formula-for-6-SDL393397542-3-629c3.jpg',
    N'https://www.alpropharmacy.com/wp-content/uploads/2020/07/69634_PediaSure_1.jpg',
    N'Abbott Pediasure Vanilla Flavor 1.6kg (1-10 years)',
    600000.00,
    850,
    4,
    N'1-10 tuổi',
    N'',
    N'Pediasure',
    N'Singapore',
    N'Abbott Manufacturing Singapore Private Limited',
	20,
	978,
	730,
	1
),
(
    5, 
    N'Cung cấp các dưỡng chất cần thiết cho sự phát triển của não, thị lực và võng mạc của thai nhi. Cải thiện hệ tiêu hóa, ngăn ngừa táo bón và tăng cường hấp thu dưỡng chất cho mẹ. Tăng cường miễn dịch và giảm nguy cơ thiếu máu và thiếu sắt trong thai kỳ. Hỗ trợ phát triển xương thai nhi và ngăn ngừa loãng xương cho mẹ.', 
    N'Optimum Mama Gold là sản phẩm của Vinamilk, thương hiệu sữa hàng đầu tại Việt Nam. Sản phẩm được thiết kế đặc biệt dành cho các bà mẹ mang thai và cho con bú, cung cấp các dưỡng chất cần thiết cho thai kỳ và sự phát triển tối ưu của thai nhi. Sản phẩm giúp cải thiện các vấn đề tiêu hóa và tăng cường hấp thu dưỡng chất cho mẹ.', 
    N'https://cdn1.concung.com/2019/06/40489-50100/optimum-mama-gold-400g.jpg', 
	N'https://cdn1.concung.com/2019/02/40489-46031/optimum-mama-gold-400g.jpg',
	N'https://cdn1.concung.com/2019/02/40489-46025-large_mobile/optimum-mama-gold-400g.jpg',
    N'Optimum Mama Gold', 
    180700.00, 
    400, 
    5, 
    N'', 
    N'1-3 tháng', 
    N'Vinamilk', 
    N'Việt Nam', 
    N'Vinamilk',
	15,
	800,
	490,
	1
),
(
    6, 
    N'Hỗ trợ tiêu hóa khỏe mạnh, phát triển não bộ và thị giác, tăng cường hệ miễn dịch và cung cấp các dưỡng chất thiết yếu cho sự hình thành xương và hồng cầu.', 
    N'Sữa bầu Wakodo Maternity Milk là sản phẩm sữa công thức hàng đầu của Wakodo tại Nhật Bản. Sữa chứa chất xơ GOS, DHA, Vitamin A, C, E, Canxi, Axit Folic và Sắt giúp hỗ trợ sức khỏe và phát triển toàn diện của mẹ và thai nhi.', 
    N'https://cdn.chanhtuoi.com/uploads/2023/06/sua-bau-15.jpg', 
	N'https://concung.com/2020/03/44644-57753-large_mobile/wakodo-mom-830g.jpg',
	N'https://cdn1.concung.com/2021/08/52345-74590/sua-wakodo-mom-830g.jpg',
    N'Wakodo Maternity Milk', 
    459000.00, 
    830, 
    6, 
    N'', 
    N'1-4 tháng', 
    N'Wakodo', 
    N'Nhật Bản', 
    N'Wakodo',
	15,
	690,
	455,
	1
),
(
	7, 
    N'Công thức dinh dưỡng đầy đủ với canxi, sắt, DHA và các vi chất cần thiết. Tăng cường chất lượng sữa mẹ, ngọt tự nhiên, dễ uống và tuân theo nguyên tắc "4 KHÔNG": không chứa nguyên liệu biến đổi gen, không chất bảo quản, không màu nhân tạo và không hương liệu tổng hợp.', 
    N'Sữa bầu Royal Ausnz Pregnant Mother Formula là sản phẩm được đánh giá cao trong số các bà mẹ mang thai vì chất lượng và hương vị dễ chịu. Sản phẩm được sản xuất bởi Royal Ausnz, thương hiệu của GOTOP với 160 năm truyền thống và 100% sở hữu của Úc. Sữa được làm từ sữa bò tươi thuần chủng Úc, sử dụng công nghệ pha trộn và sấy khô tiên tiến để bảo toàn dưỡng chất.', 
    N'https://toplist.vn/images/800px/sua-bot-hoang-gia-pregnant-mother-formula-749028.jpg', 
	N'https://nhathuoc365.vn/upload_images/images/sua-hoang-gia-uc-danh-cho-ba-bau-pregnant-mother-formula.jpg',
	N'https://vivita.cdn.vccloud.vn/wp-content/uploads/2021/10/royal-ausnz-pregnant-mother-formula-3.jpg',
    N'Royal Ausnz Pregnant Mother Formula', 
    640000.00, 
    900, 
    7, 
    N'', 
    N'1-5 tháng', 
    N'Royal Ausnz', 
    N'Úc', 
    N'Royal Ausnz',
	20,
	890,
	200,
	1
),
(
    8, 
    N'Nhiều hương vị, giàu dinh dưỡng với 14 loại vitamin và khoáng chất, ít gây dị ứng, vị dễ chịu, giàu chất xơ, tập trung vào dinh dưỡng cân bằng cho thai nhi.', 
    N'Sữa bầu Morinaga, sản phẩm của Morinaga Milk Industry nổi tiếng tại Nhật Bản, được biết đến với vị ngon dễ uống và các lợi ích dinh dưỡng rõ ràng. Sữa cung cấp các dưỡng chất cần thiết cho sự phát triển toàn diện của thai nhi mà không gây tăng cân quá mức cho mẹ. Với tỷ lệ chất béo cân đối từ các nguồn như dầu cọ, dầu hạt cọ và dầu đậu nành, giúp mẹ duy trì cân nặng hợp lý. Sữa còn có nhiều hương vị và bao bì tiện lợi dễ sử dụng.', 
    N'https://cf.shopee.com.my/file/5d8c3e43ae61f2e34f4ab771ec7a3509', 
	N'https://cf.shopee.sg/file/f76377110ddddf977477f3b7bfbc74ba',
	N'https://media.karousell.com/media/photos/products/2020/6/28/meiji_milk_tea_for_pregnancy_1593357109_2f0bde11_progressive.jpg',
    N'Morinaga Maternity Milk', 
    28000.00, 
    18, 
    8, 
    N'', 
    N'1-6 tháng', 
    N'Morinaga', 
    N'Nhật Bản', 
    N'Morinaga Milk Industry',
	10,
	678,
	400,
	1
),
(
    9,
    N'Dinh dưỡng toàn diện, hàm lượng vitamin cao, thúc đẩy sự phát triển của thai nhi, ngăn ngừa táo bón, vị dễ uống.',
    N'Dielac Mama Gold, sản phẩm của Vinamilk, được đánh giá cao vì nâng cao sức khỏe mẹ và hỗ trợ phát triển thai nhi. Sữa cung cấp các khoáng chất và vitamin thiết yếu, ngăn ngừa tiền sản giật và thúc đẩy sự phát triển khỏe mạnh của thai nhi. Sữa cũng cải thiện sự chuyển hóa và hấp thu sắt, với vị ngon dễ uống ngăn ngừa buồn nôn.',
    N'https://bizweb.dktcdn.net/100/437/188/products/vnm-dielac-mama-gold-400g.jpg?v=1631760275827',
    N'https://trungtamthuoc.com/images/products/sua-dielac-mama-gold-4-a0172.jpg',
    N'https://cdn.tgdd.vn/Products/Images/2382/193907/bhx/sb-dielac-mama-gold-hg-400g-bhx-3-org.jpg',
    N'Dielac Mama Gold',
    136000.00,
    400,
    5,
    N'',
    N'1-7 tháng',
    N'Vinamilk',
    N'Việt Nam',
    N'Vinamilk',
	10,
	500,
	600,
	1
),
(
    10, 
    N'Cung cấp các dưỡng chất thiết yếu, công thức DualCare+, hỗ trợ sự phát triển của thai nhi, tăng cường sức khỏe tiêu hóa, nâng cao sức khỏe của mẹ, vị dễ uống.', 
    N'Frisomum Gold của FrieslandCampina nổi tiếng với công thức DualCare+ độc đáo, cung cấp prebiotics và probiotics để có lợi cho sức khỏe mẹ và thai nhi. Sữa được làm từ 100% sữa tự nhiên Hà Lan, cung cấp các dưỡng chất thiết yếu như chất xơ, sucrose, DHA, choline, vitamin và khoáng chất. Sản phẩm đảm bảo một thai kỳ khỏe mạnh và hỗ trợ sự phát triển não, xương và răng cho bé, đồng thời duy trì sức khỏe tiêu hóa và giảm buồn nôn cho mẹ.', 
    N'https://cdn.medigoapp.com/product/sua_frisomum_gold_huong_vani_900g_1622099398_285155d243.jpg', 
	N'https://th.bing.com/th/id/OIP.L924EbQrUHZ1bg-k1w7PXgHaHa?rs=1&pid=ImgDetMain',
	N'https://th.bing.com/th/id/OIP.Q-5cX_mKuwzgbxf1ZiHfBgHaHa?rs=1&pid=ImgDetMain',
    N'Frisomum Gold', 
    568500.00, 
    900, 
    9, 
    N'', 
    N'1-8 tháng', 
    N'FrieslandCampina', 
    N'Hà Lan', 
    N'FrieslandCampina',
	20,
	900,
	500,
	1
),
(
    11, 
    N'Tăng cường hệ miễn dịch, cân bằng dinh dưỡng, hỗ trợ sức khỏe tiêu hóa, phát triển não bộ và thị giác, nâng cao sức khỏe xương, ngăn ngừa dị tật ống thần kinh.', 
    N'ColosBaby for Mum, được thiết kế với công thức dinh dưỡng cân bằng, chứa kháng thể IgG từ sữa non ColosIgG 24h nhập khẩu từ Mỹ. Sữa tăng cường hệ miễn dịch, ngăn ngừa bệnh tật trong thai kỳ và hỗ trợ phát triển khỏe mạnh cho thai nhi. Giàu protein và ít chất béo, sữa giúp mẹ tránh tăng cân quá mức trong khi cung cấp các dưỡng chất thiết yếu. Sản phẩm cũng bao gồm DHA, Choline và Vitamin A, hỗ trợ phát triển não bộ và thị giác. Ngoài ra, sữa còn cung cấp các dưỡng chất cần thiết cho xương chắc khỏe và ngăn ngừa dị tật ống thần kinh.', 
    N'https://bizweb.dktcdn.net/100/437/188/products/9ebf63e0032fc809335c0768a83ef9df.jpg?v=1636777197990', 
	N'https://th.bing.com/th/id/R.26f67f9e7fee38fa68881bb2a5fd8509?rik=oUfymMKZ%2fRjzaA&pid=ImgRaw&r=0',
	N'https://meiube.com/wp-content/uploads/2022/07/ColosBaby-Mum-..jpg',
    N'ColosBaby for Mum', 
    320000.00, 
    400, 
    5, 
    N'', 
    N'1-9 tháng', 
    N'Vitadairy', 
    N'Việt Nam', 
    N'Vitadairy',
	15,
	400,
	300,
	1
),
(
	12, 
    N'Công thức dinh dưỡng với các dưỡng chất quan trọng như canxi, sắt, kẽm, DHA và các loại vitamin thiết yếu. Tăng cường sức đề kháng, hỗ trợ phát triển trí não và thị giác cho thai nhi, giúp mẹ khỏe mạnh trong suốt thai kỳ.', 
    N'Anmum Materna, sản phẩm của Fonterra Brands, được đặc chế để cung cấp dinh dưỡng tối ưu cho mẹ và thai nhi. Với công thức chứa đầy đủ các dưỡng chất cần thiết, sữa giúp duy trì sức khỏe và tăng cường sức đề kháng cho mẹ, đồng thời hỗ trợ phát triển trí não và thị giác cho thai nhi. Sản phẩm không chỉ bổ sung dinh dưỡng mà còn giúp giảm nguy cơ táo bón và buồn nôn nhờ hàm lượng chất xơ cao.', 
    N'https://d2t3trus7wwxyy.cloudfront.net/catalog/product/a/n/anmum-materna-800g_2.jpg', 
	N'https://th.bing.com/th/id/OIP.X06LjV4RWmV1AECGlfL-uwHaFj?pid=ImgDet&w=474&h=355&rs=1',
	N'https://th.bing.com/th/id/OIP.CEFLwXgkGX9ipNkGcNUMkgHaFj?pid=ImgDet&w=474&h=355&rs=1',
    N'Anmum Materna', 
    315000.00, 
    800, 
    8, 
    N'', 
    N'1-10 tháng', 
    N'Fonterra Brands', 
    N'New Zealand', 
    N'Fonterra Brands',
	12,
	800,
	350,
	1
),

 (13,
 N'Enfamama A+ được bổ sung hàm lượng DHA cao và các dưỡng chất thiết yếu như canxi, choline, axit folic, sắt, vitamin D, B6, B12, quan trọng cho phụ nữ mang thai và cho con bú.',
 N'Sữa Enfamama A+ dành cho bà bầu được đặc chế để hỗ trợ sự hình thành tế bào não sớm, tăng cường khả năng nhận thức, trí nhớ và chỉ số IQ cho trẻ. Nó giúp ngăn ngừa mất xương sau sinh ở phụ nữ mang thai và tăng cường tiêu hóa, giảm triệu chứng ốm nghén.',
 N'https://cdn1.concung.com/2021/10/47170-76308-large_mobile/enfamama-a-chocolate-830g.jpg',
 N'https://down-vn.img.susercontent.com/file/vn-11134207-7qukw-lg371d9pkay226',
 N'https://suabottot.com/wp-content/uploads/2022/01/sua-enfamama-vani_2.jpg',
 N'Enfamama A+ Maternity Milk',
 430000.00,
 830,
 12,
 N'',
 N'1-11 tháng',
 N'Enfamama',
 N'Hoa Kỳ',
 N'Mead Johnson Nutrition',
 10,
 578,
 400,
 1
 ),
 (14,
 N'Sữa XO dành cho bà bầu bao gồm 39 dưỡng chất quan trọng, giàu sắt và axit folic, với chất xơ thực phẩm, Fructo-oligosaccharide (FOS), canxi, vitamin D, CPP, lactoferrin, nucleotide, mucin. Không sử dụng sucrose, giảm nguy cơ tiểu đường thai kỳ.',
 N'Sữa XO dành cho bà bầu từ Namyang, Hàn Quốc, được đặc chế để giảm nguy cơ thiếu máu cho phụ nữ mang thai, ngăn ngừa táo bón, tăng cường hoạt động của vi khuẩn có lợi cho đường ruột, tăng cường hấp thu canxi, kích thích tiết sữa và giảm sưng sau sinh. Nó giúp ngăn ngừa dị tật ống thần kinh ở thai nhi.',
 N'https://cf.shopee.com.my/file/77a439e2e37daebc9f9fcd8fc148e04a',
 N'https://concung.com/2020/11/48668-68125-large_mobile/combo-3-lon-xo-mom-gt-400g.jpg',
 N'https://product.hstatic.net/200000405233/product/xo-mom-2-800g_475e54a0fd9b4e0c9b1c34a78ca70252_grande.png',
 N'XO Maternity Milk',
 260000.00,
 400,
 13,
 N'',
 N'1-12 tháng',
 N'Namyang',
 N'Hàn Quốc',
 N'Namyang Dairy Products',
 20,
 490,
 500,
 1
 ),
 (15,
 N'Cung cấp các dưỡng chất thiết yếu cho mẹ và thai nhi, hỗ trợ phát triển toàn diện và khỏe mạnh trong suốt thai kỳ. Bao gồm canxi, chất xơ, DHA, axit folic, omega 3, omega 6, sắt, magie, vitamin B6 và nhiều hơn nữa.',
 N'Sữa Bimbosan Lady từ HOCHDORF Swiss Nutrition, Thụy Sĩ, được đặc chế để hỗ trợ sự hình thành cấu trúc xương của thai nhi, thúc đẩy vi khuẩn có lợi cho ruột để hấp thu dưỡng chất tốt nhất và ngăn ngừa táo bón trong thai kỳ. Nó giúp phát triển thị giác và não của thai nhi, tăng cường hệ tuần hoàn và giảm căng thẳng cũng như triệu chứng ốm nghén trong thai kỳ.',
 N'https://bizweb.dktcdn.net/thumb/1024x1024/100/416/540/products/bimlady-800.jpg?v=1694057279543',
 N'https://bizweb.dktcdn.net/thumb/large/100/416/540/products/anh-noi-bat-bimbosan-lady-02-16fcd7e9-1b75-4a06-b698-cc2409f1cd7d.jpg?v=1671504573437',
 N'https://bimbosankh.com/wp-content/uploads/Bimbosan-3-24-months-03.png',
 N'Bimbosan Lady Milk',
 656000.00,
 800,
 14,
 N'',
 N'1-13 tháng',
 N'Bimbosan',
 N'Thụy Sĩ',
 N'HOCHDORF Swiss Nutrition',
 10,
 530,
 700,
 1
 ),
 (16,
 N'Sữa bầu Metamom cung cấp các dưỡng chất thiết yếu như protein, chất béo, DHA, omega-3, omega-6, carbohydrate, chất xơ và polyols. Nó cũng bao gồm các vitamin thiết yếu như vitamin nhóm B và vitamin D3, hỗ trợ nhu cầu dinh dưỡng của bà mẹ mang thai.',
 N'Sữa bầu Metamom từ Nutricare, Việt Nam, có công thức ít đường giúp giảm mỡ, dễ hấp thụ và giúp ngăn ngừa táo bón với hương vị thơm ngon. Nó giảm nguy cơ tiểu đường thai kỳ, hỗ trợ phát triển xương và hệ miễn dịch, và hỗ trợ phát triển não bộ.',
 N'https://nutricare.com.vn/wp-content/uploads/2021/11/Metamom-Cam-900g.png',
 N'https://nutricare.com.vn/wp-content/uploads/2021/11/salekit_Metamom-1.png',
 N'https://cdn.tgdd.vn/Products/Images/2382/229295/bhx/sua-bot-nutricare-metamom-huong-socola-lon-900g-202010060954222331.jpg',
 N'Metamom Maternity Milk',
 345000.00,
 900,
 15,
 N'',
 N'1-14 tháng',
 N'Metamom',
 N'Việt Nam',
 N'Nutricare',
 20,
 600,
 300,
 1
 ),
 (17,
 N'Sữa NAN Optipro 2 hỗ trợ hấp thụ tối ưu với protein Optipro, tăng cường tiêu hóa với Probiotic Bifidus BL, và ngăn ngừa táo bón với chất xơ FOS. Nó giàu DHA, ARA, vitamin và khoáng chất cho sự phát triển toàn diện về thể chất và trí não. Hương vị ngọt nhẹ, thích hợp cho trẻ chuyển từ sữa mẹ sang sữa công thức.',
 N'Sữa NAN Optipro 2 là công thức sữa cho bé nổi tiếng từ Nestlé, Thụy Sĩ. Công thức dịu nhẹ này được các chuyên gia khuyên dùng vì lợi ích cho hệ tiêu hóa. Các thành phần chính bao gồm protein Optipro cho hấp thụ tối đa, Probiotic Bifidus BL để thúc đẩy vi khuẩn có lợi cho ruột, chất xơ hòa tan FOS để ngăn ngừa táo bón và cải thiện hấp thụ dưỡng chất, cùng với DHA, ARA, vitamin và khoáng chất cho sự phát triển toàn diện.',
 N'https://th.bing.com/th/id/R.66a4eb1a9598982e25b560d1452b76b5?rik=GlkI4rWMu4mJZA&riu=http%3a%2f%2fshop.nestlebaby.com.au%2fcdn%2fshop%2ffiles%2f07613287040510_C1C1.jpg%3fv%3d1687916532&ehk=cLyr%2b8X3tBrzM7t9zH%2b3uQhzCyBsRJI23%2b65kT4JPSA%3d&risl=&pid=ImgRaw&r=0',
 N'https://cdn-v2.kidsplaza.vn/media/wysiwyg/product/suabotchobe/sua-nestle-nan-pro-2-800g-5.JPG',
 N'https://th.bing.com/th/id/OIP.wG5NqixTVdI7Ml3xR8xD0gHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'Sữa Bột Nestle NAN Optipro 2',
 350000.00,
 800,
 16,
 N'6 - 12 tháng',
 N'',
 N'Nestlé',
 N'Thụy Sĩ',
 N'Nestlé',
 10,
 880,
 200,
 1
 ),
 (18,
 N'Sữa Merrikiz Gold Mother giúp các bà mẹ bổ sung dưỡng chất thiết yếu trong suốt thai kỳ, bao gồm protein, canxi, sắt, chất xơ, axit folic và DHA.',
 N'Sữa bầu Merrikiz Gold Mother từ Eneright Nutrition, Việt Nam, có hương vani hấp dẫn, thậm chí đối với những người có khẩu vị nhạy cảm. Nó ngăn ngừa thiếu hụt dưỡng chất và mệt mỏi ở các bà mẹ, hỗ trợ tiêu hóa, giảm táo bón và hỗ trợ phát triển não bộ và xương cho bé trong thai kỳ.',
 N'https://eneright.vn/wp-content/uploads/2019/08/Merrikiz-Mother-Gold-900g.png',
 N'https://down-my.img.susercontent.com/file/4bf050e699dc62f81ab4c1b17226035c',
 N'https://sue.vn/wp-content/uploads/2021/09/thanh-phan-sua-merrikiz-gold-cho-me-bau-duoc-trinh-bay-ro-rang.jpg',
 N'Merrikiz Gold Mother',
 483000.00,
 900,
 17,
 N'',
 N'1-15 tháng',
 N'Merrikiz',
 N'Việt Nam',
 N'Eneright Nutrition',
 10,
 678,
 400,
 1
 ),
 (19,
 N'Giúp phát triển trí não, tăng cường miễn dịch, hỗ trợ hệ tiêu hóa cho bà bầu và ngăn ngừa táo bón, thúc đẩy phát triển chiều cao cho bé và duy trì sức khỏe tổng thể trong suốt thai kỳ.',
 N'Sữa bầu Oggi Mum từ Vitadairy, Việt Nam, chứa các dưỡng chất thiết yếu như DHA, choline, FOS, kẽm, selenium, canxi và phốt pho. Nó giúp phát triển trí não, tăng cường miễn dịch, hỗ trợ tiêu hóa, ngăn ngừa táo bón, thúc đẩy phát triển chiều cao cho bé và duy trì sức khỏe tổng thể trong suốt thai kỳ.',
 N'https://product.hstatic.net/200000480281/product/oggi_mum_-_900g__2__59085d693eee492bb74da8989e5de54b_grande.png',
 N'https://product.hstatic.net/200000480281/product/oggi_mum_-_900g__3__212eff81c63247a68d3748fc2788d7c7_master.png',
 N'https://product.hstatic.net/200000480281/product/oggi_mum_-_900g__1__07f8fda6a85847d9858016cdfd7fd7d2_master.png',
 N'Oggi Mum',
 305000.00,
 900,
 18,
 N'',
 N'3-5 tháng',
 N'Oggi',
 N'Việt Nam',
 N'VitaDairy',
 20,
 910,
 500,
 1
 ),
 (20,
 N'Sữa Nuti IQ Mum Gold dành cho phụ nữ mang thai sử dụng công thức IQMax mới và chứa nhiều vitamin và khoáng chất thiết yếu cho thai nhi và sức khỏe của mẹ. Sản phẩm là thương hiệu Việt Nam, phù hợp với thể chất và khẩu vị của phụ nữ Việt. Giá cả phải chăng, hương vị ngọt nhẹ, dễ uống, có sẵn hương sô cô la và vani. Không bị vón cục khi pha, không ngấy và ngăn ngừa táo bón ở bà bầu.',
 N'Sữa bầu Nuti IQ Mum Gold từ Nutifood, Việt Nam, bao gồm các dưỡng chất thiết yếu như nano canxi, axit folic, sắt, FOS/Inulin và lutein. Công thức hỗ trợ sức khỏe của mẹ và thai nhi, ngăn ngừa táo bón, phù hợp với khẩu vị và thể chất của người Việt. Hương vị ngọt nhẹ, có sẵn hương sô cô la và vani, dễ pha mà không bị vón cục.',
 N'https://i.imgur.com/vdoSxTB.jpg',
 N'https://toplist.vn/images/800px/nuti-iq-gold-mum-504840.jpg',
 N'https://sieuthihoaba.com.vn/wp-content/uploads/2020/10/sua-bot-nutifood-mum-gold-lon-900g-201811301415452503-600x450.jpg',
 N'Nuti IQ Mum Gold',
 220000.00,
 900,
 19,
 N'',
 N'3-6 tháng',
 N'Nuti IQ',
 N'Việt Nam',
 N'Nutifood',
 10,
 1290,
 500,
 1
),

(21,
 N'Fortimel Powder is rich in energy and protein, ideal for underweight pregnant women. It also contains a blend of soluble fibers including FOS, GOS, and pectin, which helps improve constipation in pregnant women.',
 N'Nutricia Fortimel Powder từ Nutricia, Hà Lan, giàu năng lượng và protein, phù hợp cho phụ nữ mang thai thiếu cân. Hương vanilla thơm ngon và dễ uống, ngay cả với những người không thường xuyên uống sữa. Nội dung protein cao, với 65% protein whey và 35% protein casein, đảm bảo hấp thu và tiêu hóa dễ dàng. Giúp giảm nguy cơ suy dinh dưỡng ở thai nhi và cải thiện tình trạng táo bón ở phụ nữ mang thai.',
 N'https://th.bing.com/th/id/OIP.HjdZr1zhH7V-1tVYQaa2cgHaHa?rs=1&pid=ImgDetMain',
 N'https://th.bing.com/th/id/R.fc21a6ea7ea92fe358cde6d19c02dc0d?rik=%2bEsJ1DlS54RrDQ&pid=ImgRaw&r=0',
 N'https://nhathuocviet.com/wp-content/uploads/2022/07/nutricia-fortimel-powder-2.jpg',
 N'Nutricia Fortimel Powder',
 350000.00, -- Giá cho hộp 335g trong VND
 335, -- Trọng lượng trong gram cho mỗi hộp
 20, -- BrandMilkID cho Fortimel
 N'', 
 N'3-7 tháng', 
 N'Fortimel',
 N'Hà Lan', -- Nước sản xuất
 N'Nutricia',
 10,
 1500,
 300,
 1 
),
(22,
 N'Milky AuZ Mom ngăn ngừa thiếu máu, cải thiện tiêu hóa, và tăng cường miễn dịch. Đóng vai trò quan trọng trong việc hỗ trợ phát triển não bộ của thai nhi, giảm nguy cơ các khuyết tật ống thần kinh, và hỗ trợ hình thành và phát triển xương của thai nhi.',
 N'Sữa bà bầu Milky AuZ Mom từ TGD, Việt Nam, chứa sắt, sợi (FOS), vitamin C và D3. Ngoài ra còn cung cấp DHA, ALA, taurine, choline, axit folic, canxi và selen. Sữa này ngăn ngừa thiếu máu, cải thiện tiêu hóa, tăng cường sức đề kháng miễn dịch, hỗ trợ phát triển não bộ, giảm nguy cơ khuyết tật ống thần kinh, và hỗ trợ hình thành và phát triển xương của thai nhi.',
 N'https://down-my.img.susercontent.com/file/b0eb13dc49d3b75f754ad7043a2c90f8',
 N'https://cf.shopee.com.my/file/2fd839be577a6e5a1f0041273721c6d0',
 N'https://down-vn.img.susercontent.com/file/c561a2795dde2fa436bf59be68eaa536',
 N'Milky AuZ Mom',
 520000.00, -- Giá cho hộp 850g trong VND
 850, -- Trọng lượng trong gram cho mỗi hộp
 21, -- BrandMilkID cho Milky AuZ
 N'', 
 N'3-8 tháng', 
 N'Milky AuZ',
 N'Việt Nam', -- Nước sản xuất
 N'TGD',
 20,
 1390,
 200,
 1
),
(23,
 N'Kazu Mom Gold hỗ trợ tiêu hóa khỏe mạnh và ngăn ngừa táo bón trong thai kỳ. Giúp giảm căng thẳng, cải thiện giấc ngủ tự nhiên cho các bà mẹ, ngăn ngừa chuột rút, tê và tối ưu hóa phát triển xương cho thai nhi.',
 N'Sữa bà bầu Kazu Mom Gold từ Aiwado, Nhật Bản, được chứng nhận bởi Hiệp hội Y khoa Nhật Bản, cung cấp dinh dưỡng toàn diện để tăng cường sức khỏe của mẹ và đảm bảo dinh dưỡng đầy đủ cho sự phát triển của thai nhi. Bao gồm sự kết hợp của các sợi tan trong nước cao cấp (GOS Nhật Bản, 2\FL-HMO, FOS/Inulin) cùng với kẽm, lysine, vitamin nhóm B, lactium và canxi. Sữa này hỗ trợ tiêu hóa khỏe mạnh, giảm căng thẳng, cải thiện giấc ngủ và tối ưu hóa phát triển xương cho thai nhi.',
 N'https://media.shoptretho.com.vn/upload/20230527/sua-bot-aiwado-kazu-mom-gold-350g-2.png',
 N'https://th.bing.com/th/id/OIP.1teFJO8qyKCo4SMZzqJxMAHaE8?rs=1&pid=ImgDetMain',
 N'https://file.hstatic.net/200000394709/file/kazu_mom-01_a3bdddc45bf04e898233c3e51463012b_b4dad4a04486420483c5f49555faccd6.jpg',
 N'Kazu Mom Gold',
 258000.00, -- Giá cho hộp 350g trong VND
 350, -- Trọng lượng trong gram cho mỗi hộp
 22, 
 N'', 
 N'3-9 tháng', 
 N'Kazu Mom',
 N'Nhật Bản', -- Nước sản xuất
 N'Aiwado',
 10,
 1600,
 300,
 1
),
(24,
 N'Endolac Mum+ cung cấp dinh dưỡng toàn diện cho các bà mẹ, hỗ trợ phát triển não và thị lực cho thai nhi, thúc đẩy một thai kỳ khỏe mạnh và ngăn ngừa khuyết tật, tăng cường miễn dịch, cải thiện tiêu hóa và sự thèm ăn, cũng như giúp hình thành máu cho một thai kỳ khỏe mạnh.',
 N'Endolac Mum+ sữa bầu từ Eneright Nutrition, Việt Nam, đảm bảo cung cấp các chất dinh dưỡng cần thiết như DHA, axit folic, sắt, lutein, sữa đầu non, cùng với các vitamin và khoáng chất khác qua 2 ly Endolac Mum+ mỗi ngày. Sản phẩm này cung cấp dinh dưỡng toàn diện cho các bà mẹ, hỗ trợ phát triển não và thị lực cho thai nhi, thúc đẩy một thai kỳ khỏe mạnh và ngăn ngừa khuyết tật, tăng cường miễn dịch, cải thiện tiêu hóa, tăng cường sự thèm ăn, và giúp hình thành máu cho một thai kỳ khỏe mạnh.',
 N'https://eneright.vn/wp-content/uploads/2019/05/endolac-mum-900g.png',
 N'https://down-vn.img.susercontent.com/file/83afb688f9860f85b61129bc2ab03907',
 N'https://down-vn.img.susercontent.com/file/ee0cad0e3270efda63a64d34d43a2e50',
 N'Endolac Mum+',
 430000.00, -- Giá mỗi hộp 900g tính bằng VND
 900, -- Trọng lượng trong gram mỗi hộp
 23, -- BrandMilkID cho Endolac
 N'', 
 N'3-10 tháng',
 N'Endolac',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Eneright Nutrition',
 20,
 1490,
 500,
 1
),
(25,
 N'Smarta Mom hỗ trợ hấp thu chất dinh dưỡng, giảm táo bón, có chỉ số glycemic index thấp để giảm nguy cơ tiểu đường thai kỳ, hỗ trợ phát triển não và thị lực cho bé, và hỗ trợ sự phát triển xương chắc khỏe.',
 N'Smarta Mom sữa bầu từ Nutricare, Việt Nam, chứa 27 loại vitamin và khoáng chất cần thiết, DHA từ dầu cá tự nhiên, cùng với choline, taurine, iodine, omega 3, 6, vitamin K2, vitamin D3. Sản phẩm này hỗ trợ hấp thu chất dinh dưỡng, giảm táo bón, có chỉ số glycemic index thấp để giảm nguy cơ tiểu đường thai kỳ, hỗ trợ phát triển não và thị lực cho bé, và thúc đẩy sự phát triển xương chắc khỏe.',
 N'https://th.bing.com/th/id/R.b5bec9c801194549a158577d6a198c4f?rik=dicGKFAjhcl1CQ&pid=ImgRaw&r=0',
 N'https://th.bing.com/th/id/OIP.t_QVm2mdSfqta8a3rLwDJwHaEX?rs=1&pid=ImgDetMain',
 N'https://cf.shopee.vn/file/be8ab345f7bce082b0c932f8e4cda718',
 N'Smarta Mom',
 415000.00, -- Giá mỗi hộp 900g tính bằng VND
 900, -- Trọng lượng trong gram mỗi hộp
 24, -- BrandMilkID cho Nutricare
 N'', 
 N'3-11 tháng', 
 N'Nutricare',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Nutricare',
 10,
 1200,
 500,
 1
),
(26,
 N'Herogen Mom cung cấp các chất dinh dưỡng cần thiết cho các bà mẹ mang thai, ngăn ngừa thiếu máu, giảm nguy cơ khuyết tật ống thần kinh ở thai nhi, hỗ trợ tăng cân thai nhi ổn định, nâng cao phát triển não và thị lực, giảm căng thẳng, và hỗ trợ giấc ngủ tự nhiên cho các bà mẹ mang thai.',
 N'Herogen Mom sữa bầu từ Nutriking, Việt Nam, chứa protein, sợi tan, dầu cá (chứa DHA), khoáng chất như canxi, magiê, sắt, kẽm, đồng, iod, mangan, selen và các vitamin như A, D3, E, K1, C, B1, B2, B6, B12, axit folic, choline, lactium. Sản phẩm cung cấp các chất vi lượng quan trọng cho các bà mẹ mang thai, ngăn ngừa thiếu máu, giảm nguy cơ khuyết tật ống thần kinh ở thai nhi, hỗ trợ tăng cân thai nhi ổn định, nâng cao phát triển não và thị lực, giảm căng thẳng, và hỗ trợ giấc ngủ tự nhiên cho các bà mẹ mang thai.',
 N'https://lzd-img-global.slatic.net/g/p/e05b9b44450d9223913adabb3a20e0e5.jpg_720x720q80.jpg',
 N'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmwla7wd4rmn32',
 N'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmwla7wd667395',
 N'Herogen Mom',
 485000.00, -- Giá mỗi hộp 900g tính bằng VND
 900, -- Trọng lượng trong gram mỗi hộp
 25, -- BrandMilkID cho Nutriking (giả sử là 27 như đã chèn ở trên)
 N'', 
 N'3-12 tháng', 
 N'Nutriking',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Nutriking',
 10,
 1010,
 800,
 1
),
(27,
 N'Friso Gold cung cấp các chất dinh dưỡng cân bằng để hấp thu tối ưu, chứa sợi GOS để hỗ trợ tiêu hóa khỏe mạnh, có hương vị nhẹ nhàng ngọt ngào, không chứa chất bảo quản và hương liệu nhân tạo, và hỗ trợ phát triển não bộ và hệ thần kinh với các chất dinh dưỡng thiết yếu như DHA.',
 N'Friso Gold từ Royal Friesland Campina, Hà Lan, có sẵn dưới dạng sữa bột và sữa uống sẵn. Giá cả dao động từ 400,000 đến 900,000 VND tùy loại sản phẩm. Friso, thành lập từ năm 1966, đã trở thành một trong những công ty sữa lớn nhất trên toàn cầu. Tất cả sản phẩm được sản xuất dưới điều kiện tốt nhất và được kiểm soát chất lượng nghiêm ngặt, khiến chúng được đón nhận rộng rãi trên toàn thế giới. Những lợi thế chính bao gồm tỷ lệ dinh dưỡng cân bằng để hấp thu tối ưu, sợi GOS giúp tiêu hóa khỏe mạnh, hương vị nhẹ nhàng ngọt ngào, không chứa chất bảo quản hoặc hương liệu nhân tạo, và các chất dinh dưỡng thiết yếu cho sự phát triển của trẻ, đặc biệt là sợi và DHA cho sự phát triển não bộ và hệ thần kinh. Các sản phẩm Friso có khả năng hấp thu cao, nâng cao miễn dịch, phát triển não bộ và tổng hợp dinh dưỡng chung.',
 N'https://cdn.shopify.com/s/files/1/0274/6636/7062/products/S3-900g-BO4_800x.jpg?v=1641548133',
 N'https://www.frisogold.com.my/sites/g/files/jgsirj111/files/styles/570xauto/public/2022-10/image1.png?itok=S-ApdkvP',
 N'https://th.bing.com/th/id/OIP.BDXb9-k_aES39d4UlaQiBAHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'Friso Gold',
 400000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị
 26, -- BrandMilkID cho Friso (giả sử là 28 như đã chèn ở trên)
 N'1+ tuổi', 
 N'', 
 N'Friso',
 N'Hà Lan', -- Quốc gia sản xuất
 N'Royal Friesland Campina',
 20,
 1900,
 600,
 1
),
(28,
 N'Glico milk mang đến hương vị ngọt nhẹ giống như sữa mẹ, giúp trẻ ăn ngon và ngăn ngừa táo bón với vi khuẩn Bifidus, tăng cường miễn dịch với 5 nucleotide tự nhiên, và hỗ trợ sự phát triển toàn diện về chiều cao, cân nặng và não bộ. Glico milk cũng cân bằng mức độ natri giống như sữa mẹ để tránh các vấn đề như nôn mửa, tiêu chảy hoặc hội chứng hôn mê do mất cân bằng natri.',
 N'Glico milk từ Nhật Bản có sẵn dưới dạng sữa bột và sữa uống sẵn. Giá cả dao động từ 99,000 đến 525,000 VND tùy loại sản phẩm. Glico, thương hiệu hàng đầu tại Nhật Bản, nổi tiếng với sữa của họ gần giống với hương vị của sữa mẹ. Sản phẩm này nổi bật vì lợi ích tuyệt vời cho trẻ em nhưng vẫn đảm bảo hòa hợp với các tiêu chí an toàn và chất lượng. Sữa Glico thúc đẩy sự phát triển chiều cao lý tưởng, ngăn ngừa táo bón, tăng cường miễn dịch với các nucleotide tự nhiên, và hỗ trợ sự phát triển toàn diện về chiều cao, cân nặng và não bộ. Glico milk cũng duy trì mức độ natri giống như sữa mẹ, ngăn ngừa các vấn đề liên quan đến mất cân bằng natri như nôn mửa, tiêu chảy hoặc hội chứng hôn mê.',
 N'https://cf.shopee.vn/file/ee7ccc3ca175482dfbc3fbe0342e08fa',
 N'https://cf.shopee.vn/file/060f045156d395a65767751f004e6628',
 N'https://nhathuocngocanh.com/wp-content/uploads/2024/02/Glico-Icreo-Balance-Milk-3.jpg',
 N'Glico',
 525000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 850, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 27, -- BrandMilkID cho Glico (giả sử là 29 như đã chèn ở trên)
 N'0-12 tháng', 
 N'', 
 N'Glico',
 N'Nhật Bản', -- Quốc gia sản xuất
 N'Glico',
 10,
 1000,
 500,
 1
),
(29,
 N'NAN milk nhẹ dịu với tiêu hóa, giúp giảm táo bón ở trẻ em. Nó chứa các chất dinh dưỡng cân bằng, protein whey cao giúp tiêu hóa dễ dàng, vi khuẩn có lợi Bifidus BL để tăng cường miễn dịch và hỗ trợ tiêu hóa. NAN cũng tập trung vào việc bổ sung axit béo, DHA, quan trọng cho sự phát triển não bộ và võng mạc.',
 N'NAN là một thương hiệu sữa nổi tiếng thuộc tập đoàn Nestlé có trụ sở tại Thụy Sĩ. Sản phẩm NAN được sản xuất tại các quốc gia như Nga, Hà Lan, Đức và Philippines. Nhờ những đặc điểm ưu việt và luôn là một trong những thương hiệu hàng đầu về sữa dễ tiêu hóa, NAN luôn được các bà mẹ tin tưởng cho con của mình. Những điểm nổi bật bao gồm nhẹ dịu với dạ dày, giảm táo bón, chứa các chất dinh dưỡng cân bằng, protein whey cao giúp tiêu hóa dễ dàng, vi khuẩn có lợi Bifidus BL và sự tập trung vào axit béo và DHA quan trọng cho sự phát triển não bộ và võng mạc. Giá cả dao động từ 325,000 đến 780,000 VND mỗi hộp tùy vào trọng lượng và loại sản phẩm.',
 N'https://cdn1.concung.com/2022/02/44768-80774-large_mobile/nestle-nan-supreme-so-2-2hmo-800g-6-24-thang.jpg',
 N'https://th.bing.com/th/id/OIP.4Lu8pRao_-wmdpiFKUY5WAHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'https://th.bing.com/th/id/OIP.BcDJMLzMC3dkBQp9mPF9TgHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'NAN',
 325000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 800, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 28, -- BrandMilkID cho NAN (giả sử là 30 như đã chèn ở trên)
 N'6-24 tháng', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'NAN',
 N'Thụy Sĩ', -- Quốc gia sản xuất
 N'Nestlé',
 20,
 2020,
 400,
 1
),
(30, 
 N'Aptamil được đánh giá cao về khả năng hỗ trợ phát triển toàn diện não bộ ở trẻ nhỏ. Lượng canxi và vitamin D cao giúp tăng trưởng chiều cao hiệu quả. Sản phẩm bao gồm một miếng bọc bảo vệ để giúp người mua phân biệt sản phẩm chính hãng với hàng giả. Vị ngọt nhẹ tự nhiên của sữa giúp trẻ dễ dàng chuyển từ sữa mẹ sang sữa công thức. Protein whey dễ tiêu hóa và hấp thu ngăn ngừa quá tải. Thích hợp cho trẻ em dễ bị táo bón và các vấn đề tiêu hóa.',
 N'Aptamil là một thương hiệu sữa dưới tập đoàn Danone, có trụ sở tại Pháp. Đây là nhóm dinh dưỡng cho trẻ em hàng đầu châu Âu, với sản phẩm được sản xuất tại Anh và Đức. Trên thị trường Việt Nam, cả Aptamil Anh và Aptamil Đức đều có mặt. Những điểm nổi bật bao gồm hỗ trợ phát triển toàn diện não bộ, nội dung canxi và vitamin D cao giúp tăng trưởng chiều cao hiệu quả, miếng bọc bảo vệ, vị ngọt nhẹ tự nhiên, protein whey dễ tiêu hóa, và sự phù hợp cho trẻ em dễ bị táo bón và các vấn đề tiêu hóa. Giá cả dao động từ 325,000 đến 780,000 VND tùy vào trọng lượng và loại sản phẩm.',
 N'https://cdn1.concung.com/2023/11/64564-106385/spddct-aptamil-profutura-cesarbiotik-1-infant-formula-danh-cho-tre-tu-0--12-thang-tuoi-800g.png', 
 N'https://cdn1.concung.com/2023/11/64564-106386-large_mobile/spddct-aptamil-profutura-cesarbiotik-1-infant-formula-danh-cho-tre-tu-0--12-thang-tuoi-800g.png',
 N'https://th.bing.com/th/id/OIP.vsn7FXhEHBzoG5QMrj58EAHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'Aptamil',
 325000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 800, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 29, -- BrandMilkID cho Aptamil (giả sử là 27 như đã chèn ở trên)
 N'0-12 tháng', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Aptamil',
 N'Pháp', -- Quốc gia sản xuất
 N'Danone',
 10,
 1780,
 500,
 1
),
(31, -- ProductItemID cho Franci Việt Nam
 N'Sữa Franci mang lại hương vị ngon và dễ uống. Nó thành công bổ sung 3 chất dinh dưỡng: Lutein nhập khẩu từ Pháp để phát triển thị lực và não bộ, sữa dê giàu IgG từ Mỹ, và chiết xuất tổ yến cao cấp để tăng cường miễn dịch và dinh dưỡng cơ thể. Sản phẩm được sản xuất tại nhà máy Eneright, đáp ứng các tiêu chuẩn GMP và hệ thống quản lý chất lượng và an toàn thực phẩm theo các tiêu chuẩn ISO 9001:2008; ISO 22000:2005 và HACCP. Các sản phẩm đa dạng phù hợp với nhu cầu của trẻ em khó tiêu hóa và tăng trưởng chậm, các bà mẹ mang thai cần bổ sung dinh dưỡng, và người lớn tìm kiếm chăm sóc sức khỏe và ngăn ngừa đột quỵ.',
 N'Franci là một thương hiệu chuyên cung cấp thực phẩm dinh dưỡng, được thành lập và tư vấn bởi các chuyên gia dinh dưỡng hàng đầu Việt Nam và các bác sĩ nghiên cứu về dinh dưỡng cộng đồng. Với các sản phẩm đa dạng dành cho trẻ em, bà mẹ mang thai và người cao tuổi, sữa Franci được làm từ nguyên liệu hoàn toàn nhập khẩu từ châu Âu và luôn được người tiêu dùng lựa chọn và tin tưởng rộng rãi. Phạm vi giá: 253,000 – 612,000 VND (tùy vào loại sản phẩm).',
 N'https://media.sellycdn.net/files/md_1700107412807dxkkbo2Wlz.jpg',
 N'https://media.sellycdn.net/files/md_1700107412747sS1zcumoZ7.jpg',
 N'https://media.sellycdn.net/files/md_1699955041807kU989WWo6c.png', 
 N'Franci Việt Nam - Khởi nguồn tương lai Việt',
 523000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 800, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 30, -- BrandMilkID cho Franci Việt Nam (giả sử là 28)
 N'0+', 
 N'', 
 N'Franci Việt Nam',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Franci Việt Nam',
 10,
 2000,
 700,
 1
),
(32, -- ProductItemID cho GrowPLUS+
 N'GrowPLUS+ giúp trẻ em cao lớn và tăng cân mà không gây béo phì. Nó thúc đẩy tiêu hóa tốt với chuyển động ruột thường xuyên, và hương vị sữa không quá ngọt và có mùi nhẹ. Sự hiện diện của tảo gây ra cấu trúc hơi hạt sau khi pha trộn, nhưng điều này là bình thường.',
 N'GrowPLUS+ là một thương hiệu sữa được đánh giá cao từ Nutifood, Thuỵ Điển, được thiết kế đặc biệt cho trẻ em Việt Nam. Đây đặc biệt phù hợp cho trẻ em suy dinh dưỡng hoặc gầy. Các thành phần chính bao gồm hệ thống cân bằng sợi (Polydextrose và FOS/Inulin) giúp cân bằng sợi thể thể, giảm cảm giác thèm ăn và giúp trẻ duy trì cân nặng lành mạnh. Nó cung cấp 29 vitamin và khoáng chất để tăng cường miễn dịch và thúc đẩy sức khỏe tổng thể, DHA cho sự phát triển não bộ và thị giác, và canxi cho sự phát triển chiều cao. Thích hợp cho trẻ từ 1 tuổi trở lên.',
 N'https://media.sellycdn.net/files/sm_2023_07_27_02_35_09_0700_zzGHZTsmMy.jpeg', 
 N'https://th.bing.com/th/id/OIP.KbiYzHKeny-z1AOKuVzemwHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'https://suabottot.com/wp-content/uploads/2020/02/sua-grow-plus-xanh-3-400x400.jpg',
 N'GrowPLUS+',
 520000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 31, -- BrandMilkID cho Nutifood (giả sử là 2)
 N'1+ tuổi', -- Dải tuổi cho trẻ sơ sinh
 N'', -- Không có chỉ dẫn cụ thể cho bà mẹ mang thai
 N'Nutifood',
 N'Thụy Điển', -- Quốc gia sản xuất
 N'Nutifood',
 20,
 1789,
 400,
 1
),
(33, 
 N'Care 100 Gold hỗ trợ tăng cân hiệu quả, ngăn ngừa táo bón và chứa lượng cao sữa dê để tăng cường miễn dịch, giảm thiểu các bệnh thường gặp ở trẻ. Nó có hương vị ngon, tuy nhiên có thể khá ngọt đối với trẻ đang chuyển từ sữa mẹ hoặc các loại sữa ít ngọt hơn. Các nghiên cứu lâm sàng cho thấy sự tăng cân đáng kể, với sự tăng cân trung bình là 1.5kg sau 4 tháng, vượt trội hơn so với các loại sữa công thức thông thường lên đến 36.4%.',
 N'Care 100 Gold là một công thức sữa chuyên biệt của Nutricare dành cho trẻ em kén ăn, suy dinh dưỡng hoặc gầy. Nutricare, một thương hiệu sữa hàng đầu Việt Nam, phát triển các công thức dựa trên các tiêu chuẩn quốc tế với sự đóng góp từ các chuyên gia hàng đầu tại Mỹ và Nhật Bản. Các thành phần chính bao gồm DHA, Choline, Sắt để phát triển não bộ và tăng cường trí nhớ, lượng sữa dê cao kết hợp với vitamin A, C, E và Lactoferrin để có một hệ thống miễn dịch mạnh mẽ, và gấp đôi lượng Lysine và Kẽm cùng vitamin B để cải thiện sự thèm ăn và tiêu hóa. Công thức giàu protein whey, chất béo MCT và cung cấp năng lượng cao ở mức 100kcal/100ml để tăng cân hiệu quả.',
 N'https://th.bing.com/th/id/OIP.b2brUZazZhD2XYWxDB2wuQHaHa?rs=1&pid=ImgDetMain', 
 N'https://cdn1.concung.com/2020/02/44482-56888/sua-dac-tri-care-100-gold-900g-1-10-tuoi.jpg',
 N'https://cdn1.concung.com/2020/02/44482-56889/sua-dac-tri-care-100-gold-900g-1-10-tuoi.jpg',
 N'Care 100 Gold',
 450000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 24, -- BrandMilkID cho Nutricare (giả sử là 15)
 N'1 - 10 tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Nutricare',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Nutricare',
 10,
 1289,
 600,
 1
),
(34, -- ProductItemID cho Sữa bột Nutren Junior
 N'Nutren Junior hỗ trợ sức khỏe ruột với Prebiotics và Probiotics, tăng cường phát triển thể chất với protein whey và chất béo MCT dễ hấp thu, và thúc đẩy phát triển não với DHA.',
 N'Nutren Junior, sản phẩm của Nestlé từ Thụy Sĩ, lý tưởng cho trẻ em có sự thèm ăn kém. Nó chứa Prebiotics và Probiotics để hỗ trợ sức khỏe ruột, protein whey dễ hấp thu và chất béo MCT để phát triển thể chất tốt hơn, và DHA để phát triển não bộ.',
 N'https://multicare2u.com.my/pub/media/catalog/product/cache/eaed0ae37821a340f961354729500c75/_/n/_n_u_nutren_junior_800g.jpg', 
 N'https://th.bing.com/th/id/R.57c2e9df79d698a5ea51f853c9947358?rik=Z%2bOYc%2fSirW6P5Q&pid=ImgRaw&r=0',
 N'https://th.bing.com/th/id/OIP.shZss9woqWmESITQNcXXbgHaHa?rs=1&pid=ImgDetMain',
 N'Sữa bột Nutren Junior',
 450000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 800, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 16, -- BrandMilkID cho Nestlé (giả sử là 10)
 N'1 - 10 tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Nestlé',
 N'Thụy Sĩ', -- Quốc gia sản xuất
 N'Nestlé',
 10,
 1900,
 400,
 1
),
(35, -- ProductItemID cho Sữa bột Similac 1
 N'Similac 1 giúp trẻ sơ sinh tăng cân hiệu quả với protein whey, hỗ trợ sức khỏe tiêu hóa và miễn dịch với synbiotics, và thúc đẩy phát triển não bộ và thị giác với DHA.',
 N'Similac 1, từ Abbott USA, là lựa chọn hàng đầu cho dinh dưỡng sơ sinh với các thành phần tự nhiên. Nó chứa protein whey để tăng cân, synbiotics để hỗ trợ sức khỏe tiêu hóa và miễn dịch, và DHA để phát triển não bộ và thị giác.',
 N'https://th.bing.com/th/id/OIP.fd0beBs5RiuBg4QnZrFqnQHaHa?rs=1&pid=ImgDetMain',
 N'https://growiq.vn/wp-content/uploads/2023/02/Similac-1-900g-abbott-sua-0-6-thang-1024x1024.jpg',
 N'https://growiq.vn/wp-content/uploads/2023/02/Similac-2-900g-abbott-6-12-thang-600x600.jpg',
 N'Sữa bột Similac 1',
 650000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 1, -- BrandMilkID cho Abbott (giả sử là 11)
 N'0 - 6 tháng', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Similac',
 N'Mỹ', -- Quốc gia sản xuất
 N'Abbott Laboratories',
 10,
 2005,
 500,
 1
),
(36, -- ProductItemID cho Sữa bột dinh dưỡng Koko Crown Picky Eater 2
 N'Koko Crown Picky Eater 2 nâng cao sức khỏe xương với canxi, photpho và Vitamin D3, tăng cường năng lượng với hàm lượng carbohydrate và protein cao, kích thích sự thèm ăn với Vitamin B, và cải thiện tiêu hóa và miễn dịch với sợi tự nhiên GOS/FOS.',
 N'Koko Crown Picky Eater 2 là một sản phẩm dinh dưỡng chuyên biệt của Namyang Dairy Products Co., một trong những thương hiệu sữa hàng đầu của Hàn Quốc. Thiết kế dành cho trẻ kén ăn từ 2 tuổi trở lên, nó giúp trẻ phát triển xương chắc khỏe, cải thiện sự thèm ăn và nâng cao khả năng tiêu hóa.',
 N'https://th.bing.com/th/id/OIP.Kl1Stu9MzwQb_z780_ZZtwHaHa?rs=1&pid=ImgDetMain', 
 N'https://cf.shopee.vn/file/c9784dafca24914c575b0f5901d814db',
 N'https://cf.shopee.vn/file/2125c43cced3c25b7c78e695aecb33ae',
 N'Sữa bột dinh dưỡng Koko Crown Picky Eater 2',
 650000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 800, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 13, -- BrandMilkID cho Namyang (giả sử là 11)
 N'2+ tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Namyang',
 N'Hàn Quốc', -- Quốc gia sản xuất
 N'Namyang Dairy Products',
 20,
 1567,
 500,
 1
),
(37, -- ProductItemID cho Sữa bột Optimum Gold 4
 N'Optimum Gold 4 hỗ trợ phát triển não bộ và tăng trưởng chiều cao tối ưu với HMO (2-Fl) giúp tiêu hóa và miễn dịch tốt hơn, probiotics BB-12TM và LGGTM giúp hấp thu dinh dưỡng, protein whey dễ tiêu hóa giàu Alpha-lactalbumin, và 20% DHA từ tảo tinh khiết giúp phát triển não bộ.',
 N'Optimum Gold 4 là một công thức sữa cho trẻ em cao cấp của Vinamilk, thiết kế để cải thiện phát triển não bộ và chiều cao tối ưu cho trẻ. Nó bao gồm HMO (2-Fl) để cải thiện tiêu hóa và miễn dịch, probiotics BB-12TM và LGGTM để hấp thu dinh dưỡng, và protein whey giàu Alpha-lactalbumin để có kết quả tăng trưởng tốt nhất.',
 N'https://th.bing.com/th/id/R.94346d175cd748537ca8bb543635ce8f?rik=PU39UbC7d1Qnkw&pid=ImgRaw&r=0',
 N'https://th.bing.com/th/id/OIP.Fao6hYKOly7A4HNWd8s65QHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'https://th.bing.com/th/id/OIP.3V_toBHKQDpnPD1HEw-ZIQHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'Sữa bột Optimum Gold 4',
 450000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 5, -- BrandMilkID cho Vinamilk (giả sử là 5)
 N'2 - 6 tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Vinamilk',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Vinamilk',
 20,
 2500,
 600,
 1
),
(38, -- ProductItemID cho Sữa bột Dielac Grow Plus 2+
 N'Dielac Grow Plus 2+ tăng cường miễn dịch với sữa dê, thúc đẩy chiều cao với canxi cao và vitamin D3, và hỗ trợ phát triển não bộ và thị giác với DHA và các axit béo thiết yếu khác. Vitamin B, kẽm và lysine cải thiện sự thèm ăn và tăng cân.',
 N'Dielac Grow Plus 2+ của Vinamilk là một công thức tiên tiến được thiết kế để cải thiện miễn dịch và hỗ trợ tăng trưởng tối ưu. Với mức độ cao của canxi và vitamin D3, nó giúp trẻ đạt được chiều cao lý tưởng, trong khi sữa dê tăng cường hệ miễn dịch của họ. DHA, axit linoleic, axit alpha-linolenic, taurine và choline giúp phát triển não bộ và thị giác. Ngoài ra, vitamin B, kẽm và lysine thúc đẩy sự thèm ăn tốt hơn và tăng cân khỏe mạnh.',
 N'https://th.bing.com/th/id/R.edbf2d52f4ad9f6655598285a83687b7?rik=s5f5sOb8qkGvtQ&pid=ImgRaw&r=0', 
 N'https://cdn1.concung.com/2020/09/25106-64776/dielac-grow-plus-2-2-10-tuoi-900g.jpg',
 N'https://th.bing.com/th/id/OIP.GZ4muZMsNWc0zqZvKr3aowHaHa?rs=1&pid=ImgDetMain',
 N'Sữa bột Dielac Grow Plus 2+',
 450000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 5, -- BrandMilkID cho Vinamilk (giả sử là 5)
 N'2+ tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Vinamilk',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Vinamilk',
 10,
 2222,
 500,
 1
),
(39, -- ProductItemID cho Sữa bột Vinamilk ColosGold số 2 800g
 N'Vinamilk ColosGold số 2 tăng cường miễn dịch với sữa dê, probiotics và HMO, tăng cường tăng cân và phát triển chiều cao với protein whey, và hỗ trợ phát triển não bộ với DHA.',
 N'Vinamilk ColosGold số 2 là công thức dinh dưỡng dành cho trẻ từ 1-2 tuổi. Nó có chứa sữa dê 24 giờ nhập khẩu từ Mỹ, bao gồm các kháng thể IgG và sự kết hợp của Probiotics & HMO (2\-Fucosyllactose (2\-FL)) giúp cân bằng vi sinh vật đường ruột, tăng cường kháng thể IgA một cách tự nhiên, cung cấp 35 dưỡng chất cần thiết, vitamin và khoáng chất để tăng cường miễn dịch và ổn định hệ miễn dịch. Sản phẩm này giàu protein whey, giúp hấp thu dinh dưỡng và hỗ trợ tăng cân và phát triển chiều cao khỏe mạnh. Ngoài ra, 20% lượng DHA được chiết xuất từ tảo, thúc đẩy phát triển não bộ tối ưu như khuyến nghị của các chuyên gia y tế toàn cầu (FAO/WHO).',
 N'https://cdn1.concung.com/2022/01/54560-79240-large_mobile/sua-vinamilk-colosgold-so-2-800g-1-2-tuoi.jpg',
 N'https://cf.shopee.ph/file/b9467822696fb56d5e3ab90621b1e418_tn',
 N'https://cdn1.concung.com/2022/01/54560-79243-large_mobile/sua-vinamilk-colosgold-so-2-800g-1-2-tuoi.jpg',
 N'Sữa bột Vinamilk ColosGold số 2 800g',
 320000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 800, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 5, -- BrandMilkID cho Vinamilk (giả sử là 12)
 N'1-2 tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'',
 N'Vinamilk',
 N'Việt Nam', -- Quốc gia sản xuất
 N'Vinamilk',
 10,
 2333,
 600,
 1
),
(40, -- ProductItemID cho Sữa Oggi Gold 1+ 900g
 N'Sữa Oggi Gold 1+ giúp tăng cân và ngăn ngừa táo bón, hỗ trợ phát triển chiều cao, não bộ và miễn dịch cho trẻ thiếu dinh dưỡng.',
 N'Oggi Gold 1+ là bột dinh dưỡng giàu dinh dưỡng đặc biệt được thiết kế cho trẻ thiếu dinh dưỡng từ 1-10 tuổi. Nó hỗ trợ tăng cân, phát triển chiều cao, não bộ và tăng cường hệ miễn dịch. Công thức bao gồm protein whey, dầu thực vật, maltodextrin, sucrose, sợi hòa tan (FOS/Inulin), L-Lysine, MCT, dầu cá giàu DHA, khoáng chất (canxi, magie, sắt, kẽm, đồng, iod, mangan, selenium), vitamin (A, D3, E, K1, C, B1, B2, B6, B12, axit pantoten, axit folic, biotin, niacin, inositol, taurine), 2-Fucosyllactose (2\-FL HMO), hương sữa và vani. Nguyên liệu được nhập khẩu từ New Zealand.',
 N'https://th.bing.com/th/id/OIP.-3_l_xRAnUpNTLOGJ2HHUwAAAA?rs=1&pid=ImgDetMain',
 N'https://th.bing.com/th/id/OIP.WRKefdZfJujturwkCOIa7AHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'https://th.bing.com/th/id/OIP.P8la5krGOJN8rT8DdS__4QHaHa?pid=ImgDet&w=474&h=474&rs=1',
 N'Sữa Oggi Gold 1+ 900g',
 350000.00, -- Giá bắt đầu mỗi đơn vị tính bằng VND (có thể điều chỉnh nếu cần thiết)
 900, -- Trọng lượng ví dụ trong gram mỗi đơn vị (có thể điều chỉnh nếu cần thiết)
 18, -- BrandMilkID cho VitaDairy (giả sử là 14)
 N'1-10 tuổi', -- Dải tuổi phù hợp cho trẻ sơ sinh
 N'', 
 N'Oggi',
 N'Việt Nam', -- Quốc gia sản xuất
 N'VitaDairy',
 20,
 1234,
 300,
 1
);

INSERT INTO AgeRange (AgeRangeID, Baby, Mama, ProductItemID, [Delete])
VALUES
(1, N'0-1 tuổi', N'', 1, 1),
(2, N'1-3 tuổi', N'', 2, 1),
(3, N'0-1 tuổi', N'', 3, 1),
(4, N'1-10 tuổi', N'', 4, 1),
(5, N'', N'1-3 tháng', 5, 1),
(6, N'', N'1-4 tháng', 6, 1),
(7, N'', N'1-5 tháng', 7, 1),
(8, N'', N'1-6 tháng', 8, 1),
(9, N'', N'1-7 tháng', 9, 1),
(10, N'', N'1-8 tháng', 10, 1),
(11, N'', N'1-9 tháng', 11, 1),
(12, N'', N'1-10 tháng', 12, 1),
(13, N'', N'1-11 tháng', 13, 1),
(14, N'', N'1-12 tháng', 14, 1),
(15, N'', N'1-13 tháng', 15, 1),
(16, N'', N'1-14 tháng', 16, 1),
(17, N'6 - 12 tháng', N'', 17, 1),
(18, N'', N'1-15 tháng', 18, 1),
(19, N'', N'3-5 tháng', 19, 1),
(20, N'', N'3-6 tháng', 20, 1),
(21, N'', N'3-7 tháng', 21, 1),
(22, N'', N'3-8 tháng', 22, 1),
(23, N'', N'3-9 tháng', 23, 1),
(24, N'', N'3-10 tháng', 24, 1),
(25, N'', N'3-11 tháng', 25, 1),
(26, N'', N'3-12 tháng', 26, 1),
(27, N'1+ tuổi', N'', 27, 1),
(28, N'0-12 tháng', N'', 28, 1),
(29, N'6-24 tháng', N'', 29, 1),
(30, N'0-12 tháng', N'', 30, 1),
(31, N'0+', N'', 31, 1),
(32, N'1+ tuổi', N'', 32, 1),
(33, N'1 - 10 tuổi ', N'', 33, 1),
(34, N'1 - 10 tuổi', N'', 34, 1),
(35, N'0 - 6 tháng', N'', 35, 1),
(36, N'2+ tuổi', N'', 36, 1),
(37, N'2 - 6 tuổi', N'', 37, 1),
(38, N'2+ tuổi', N'', 38, 1),
(39, N'1-2 tuổi', N'', 39, 1),
(40, N'1-10 tuổi', N'', 40, 1);


INSERT INTO [Order] (CustomerID, DeliveryManID, DeliveryName, DeliveryPhone, OrderDate, ShippingAddress, TotalAmount, PaymentMethod, StorageID, [Status], [Delete])
VALUES
    (1, 1, N'Trần Văn A', '1234567890', '2023-06-01', N'Nguyễn Văn A. SĐT: 1234567890. Địa chỉ: Số nhà 123, Ngõ 456, Đường Láng, Phường Láng Thượng, Quận Đống Đa, Hà Nội, Việt Nam', 585000.00, N'VnPay', 1, N'Chờ lấy hàng', 1),
    (2, 3, N'Trần Văn C', '3234567892', '2023-06-02', N'Nguyễn Văn B. SĐT: 2345678901. Địa chỉ: Số nhà 789, Đường 123, Phường Tân Phú, Quận 7, TP Hồ Chí Minh, Việt Nam', 988200.00, N'VnPay', 2, N'Đang giao hàng', 1),
    (3, 5, N'Trần Văn E', '5234567894', '2023-06-03', N'Nguyễn Văn C. SĐT: 3456789012. Địa chỉ: Số nhà 456, Đường 789, Phường Hòa Cường Bắc, Quận Hải Châu, Đà Nẵng, Việt Nam', 1269600.00, N'VnPay', 3, N'Đã giao hàng', 1),
    (4, 7, N'Trần Văn G', '7234567896', '2023-06-04', N'Nguyễn Văn D. SĐT: 4567890123. Địa chỉ: Số nhà 321, Đường 654, Phường Lê Chân, Quận Lê Chân, Hải Phòng, Việt Nam', 1920000.00, N'VnPay', 4, N'Đã giao hàng', 1),
    (5, 9, N'Trần Văn I', '9234567898', '2023-06-05', N'Nguyễn Văn E. SĐT: 5678901234. Địa chỉ: Số nhà 789, Đường 123, Phường Phú Lợi, Thành phố Thủ Dầu Một, Bình Dương, Việt Nam', 767975.00, N'VnPay', 5, N'Đã hủy', 1);

    
INSERT INTO Payment (PaymentID, Amount, PaymentMethod, OrderID, [Delete])
VALUES
    (1, 585000.00, N'VnPay', 1, 1),
    (2, 988200.00, N'VnPay', 2, 1),
    (3, 1269600.00, N'VnPay', 3, 1),
    (4, 1920000.00, N'VnPay', 4, 1),
    (5, 767975.00, N'VnPay', 5, 1);
    

INSERT INTO OrderDetail (OrderDetailID, CustomerID, OrderID, ProductItemID, ItemName, Image, Quantity, Price, Discount, OrderStatus, StockQuantity, [Delete])
VALUES
    (1, 1, 1, 1, N'Similac Advance', 'https://mebeplaza.com/wp-content/uploads/2020/08/similac-advance-1.13kg.jpg', 1, 650000.00, 10, 2, 250, 1),
    (2, 2, 2, 2, N'Alpha Grow A+ NeuroPro', 'https://th.bing.com/th/id/OIP.6m4wJY2BlBLz_Mtkrw_qpgAAAA?rs=1&pid=ImgDetMain', 2, 549000.00, 10, 2, 530, 1),
    (3, 3, 3, 3, N'Meiji 0-1 years old Infant Formula', 'https://cdn1.concung.com/2021/04/27426-72037/meiji-infant-formula-800g-0-12-thang.jpg', 3, 529000.00, 20, 2, 500, 1),
    (4, 4, 4, 4, N'Abbott Pediasure Vanilla Flavor 1.6kg (1-10 years)', 'https://www.family.abbott/my-en/pediasure/products/pediasure-vanilla/_jcr_content/root/container/columncontrol_copy/tab_item_no_0/mediacarousel/item_1653228436183_c.coreimg.png/1669711037458/product-detail-component-pds-vanila.png', 4, 600000.00, 20, 2, 730, 1),
    (5, 5, 5, 5, N'Optimum Mama Gold', 'https://cdn1.concung.com/2019/06/40489-50100/optimum-mama-gold-400g.jpg', 5, 180700.00, 15, 2, 490, 1);
    