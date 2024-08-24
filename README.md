# Exercise 1: Background Job in .NET Core

## Giới Thiệu

Bài tập này yêu cầu phát triển một ứng dụng background job trong .NET Core để thực hiện các tác vụ sau:

- Lấy danh sách người dùng có mật khẩu chưa được cập nhật trong hơn sáu tháng.
- Cập nhật trạng thái của họ thành “REQUIRE_CHANGE_PWD”.
- Gửi thông báo email đến các người dùng này.

## Yêu Cầu

- **Cơ sở dữ liệu**: SQL với bảng người dùng bao gồm các trường: `Id`, `email`, `status`, `lastUpdatePwd`.
- **Dịch vụ gửi email**: Đã có sẵn.