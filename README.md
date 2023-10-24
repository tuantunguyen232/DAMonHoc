# DAMonHoc

1. Cài đặt Visual Studio 2022:
- Tải Visual Studio 2022: Link tải: https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false
- Chạy file VisualStudioSetup
- Chọn Continue và tiến hành download
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/1fc1b376-4b6e-43e1-a63c-2cd9b0e2f380)
- Khi hiện ra các mục lựa chọn này, thì tick chọn "ASP.NET and web development" rồi ấn Install, chờ đợi cài đặt
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/029e96eb-3d63-437d-bcff-e1aa986bb117)
- Sau khi chờ xong, chọn các tùy chọn cá nhân để hoàn thành quá trình cài đặt
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/25c313f8-7c46-454a-8b1b-52ffc894ffc4)

2. Cài đặt SQL Server
- Có thể tham khảo cài theo đường dẫn này: https://kb.pavietnam.vn/huong-dan-cai-dat-sql-server-2022.html

3. Clone code từ GitHub
- Clone code từ link này: https://github.com/tuantunguyen232/DAMonHoc

3. Khởi tạo database
- Mở SSMS, đăng nhập tài khoản server
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/a25438c4-8457-4aa9-b643-7904be676e25)
- Mở file script "QuanLyDuLich.sql" ở folder đã clone code, sau đó "Execute" file này
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/3f76d902-6a46-460e-bbb0-ad13dba2c6d9)
- Ta sẽ có database tên "QuanLyDuLieu" như sau
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/e9544e17-ad77-451e-abc4-9b39f1236140)

4. Khởi tạo project
- Sau khi đã có database, mở file "QuanLyDuLich.sln" tại folder đã clone dự án
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/fff79e72-226d-46c9-8fdb-c78de8f252a8)
- Sau đó, hệ thống sẽ tự động mở VisualStudio 2022 lên và vào mở project
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/23f65d6c-7146-43d5-ac58-c2f9c4ae8a12)

5. Khởi tạo lại Model của project
- Xóa toàn bộ file trong folder Model
- Chuột phải vào folder Model > Add > New Item
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/95bf9e22-d188-445f-847d-94661911a348)
- Tiếp theo chọn như sau
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/7eec2b03-52b3-4734-90cb-bfd62e0617c7)
- Chọn Code First from database
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/c5eac8ba-fd28-41fd-b9cd-3dd921a50a1b)
- Chọn những table cần đến như sau
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/7d58a2a4-b2cc-4713-acbc-76a565fe99f5)
- Chọn Finish và ta được các folder này
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/d203a269-a2f5-49fe-9ab7-5c3cd91bf386)
- Kiểm tra Connection String ở file Web.config, xem nó có phải tên server của mình không (Ở đây tên server của tôi là TOBI23)
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/8ae8069f-c4b4-43d4-a6b2-95c476b5dbfc)

6. Khởi chạy project
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/b9ecbf18-3627-4ba4-a7c1-562e262a9cd5)
Project sau khi đã khởi chạy
![image](https://github.com/tuantunguyen232/DAMonHoc/assets/93175976/e982023e-d6c4-43c3-9954-22c5f2f5c255)



 



