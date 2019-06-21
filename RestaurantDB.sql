CREATE DATABASE RestaurantDB --- 데이터 베이스 생선
GO
USE RestaurantDB
GO
--- 한글 출력
ALTER DATABASE CaffeDB
    COLLATE Korean_Wansung_CI_AI   
GO
--- 전체 프로그그램의 여러 가지 업무에 공동으로 필요한 데이터를 유기적으로 결합하여 테이블 6개 구성되어 있음
--- TableFood,Account,FoodCategenory,Food,Bill,BillInfo
--- 각 테이블의 구성 내용은 다음과 같음

--- 테이블의 테이블이 구성 : 테이블의 이름,테이블의 상태
CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(100) NOT NULL DEFAULT 'NONAME',
	status VARCHAR(100) NOT NULL DEFAULT 'DONT HAVE' --- 손님이 있음 없을 표시 변수
)
GO
--- 계정의 테이블 : 아이디,표시 이름,비밀번호,계정의 종료
CREATE TABLE Account
(
	UserName VARCHAR(100) PRIMARY KEY, 
	DisplayName VARCHAR(100) NOT NULL,
	PassWord VARCHAR(100) NOT NULL DEFAULT 0,  
	Type INT NOT NULL DEFAULT 0 --- 관리자이든지 직원이든지
)
GO
--- 팔리는 음식 종류 의 테이블 : 이름
CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(15) NOT NULL DEFAULT 'NONAME' ---음식이든지 음료수나 커피이든지
)
GO
--- 팔리는 음식의 테이블 : 이름,종료,가격으로 구성
CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(15) NOT NULL DEFAULT 'NONAME',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY(idCategory) REFERENCES FoodCategory(id) ---관게를 맺음
)
GO
--- 계산서의 테이블 : 날짜의 정보,주문한 테이블,상태
CREATE TABLE Bill 
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(), 
	DateCheckOut DATE NOT NULL,
	idTable INT NOT NULL, 
	status INT NOT NULL DEFAULT 0 --- 테이블의 상태 동일,결제 상태에 따라서 변경

	FOREIGN KEY (idTable) REFERENCES TableFood(id) --- 관계를 맺음
)
--- 계산서의 정보 테이블: 주문한 음식의 정보
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL, --- 계한서 지정
	idFood INT NOT NULL, --- 음식에 대한 정보 지성
	count INT NOT NULL DEFAULT 0 --- 음식 수량
	--- 관계를 맺음
	FOREIGN KEY(idBill) REFERENCES Bill(id),
	FOREIGN KEY(idFood) REFERENCES Food(id)
)
GO
--- 계정 테이블의 데이터 저장
INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES --- 관리자를 역할 계정
(   'admin', -- UserName - varchar(100)
    'HOPE', -- DisplayName - varchar(100)
    '1234', -- PassWord - varchar(100)
    1   -- Type - int --- admin
    )
INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    PassWord,
    Type
)
VALUES --- 직원을 역할 계정
(   'staff', -- UserName - varchar(100)
    'STAFF', -- DisplayName - varchar(100)
    '1234', -- PassWord - varchar(100)
    0   -- Type - int --- admin
    )
GO
--- 이름을 받아서 계정의 정보를 출력하는 프로시저
CREATE PROC USP_GetAccountByUserName
@userName VARCHAR(20) --- 매개변수
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO
--- EXEC dbo.USP_GetAccountByUserName @userName = 'admin'

--- LOGIN ACCOUNT PROC : 이름과 비밀번호를 매개변수로 받아서 계정의 정보 출력 --- 
CREATE PROC USP_LoginCheck
@userName VARCHAR(20),@passWord VARCHAR(20)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO
--- INSERT TABLE : 테이블을 10개 만듦 ---
DECLARE @i INT = 1
WHILE @i < 10
BEGIN
	INSERT dbo.TableFood(name) VALUES('TABLE ' + CAST(@i AS VARCHAR(10)))
	SET @i = @i + 1
END
GO
--- GET TABLE LIST : 테이블의 리스트를 출력하는 프로시저
CREATE PROC USP_GetTableList
AS SELECT * FROM TableFood
GO
--- EXEC USP_GetTableList

--- INSERT FoodCategory Table : 음식 종류 테이블의 데이터를 삽입---
INSERT FoodCategory (name) values ('음식') 
INSERT FoodCategory (name) values ('음류수') 
INSERT FoodCategory (name) values ('맥주') 
GO
--- INSERT Food Table : 음식 테이블 데이터를 삽입---
INSERT Food (name,idCategory,price) 
VALUES ('쇠국기쌀국수',1,'9000')
INSERT Food (name,idCategory,price) 
VALUES ('쇠고기복음밥',1,'8000')
INSERT Food (name,idCategory,price) 
VALUES ('해물복음밥',1,'8000')
INSERT Food (name,idCategory,price) 
VALUES ('분짜',1,'9500')
INSERT Food (name,idCategory,price) 
VALUES ('스프링롤',1,'6500')

INSERT Food (name,idCategory,price) 
VALUES ('사이다',2,'2000')
INSERT Food (name,idCategory,price) 
VALUES ('코카콜나',2,'2000')
INSERT Food (name,idCategory,price) 
VALUES ('베트남 커피',2,'4000')
INSERT Food (name,idCategory,price) 
VALUES ('아메리카노',2,'3000')

INSERT Food (name,idCategory,price) 
VALUES ('베트남 맥주',3,'5000')
INSERT Food (name,idCategory,price) 
VALUES ('한국 맥주',3,'5000')
INSERT Food (name,idCategory,price) 
VALUES ('유럽 맥주',3,'5000')
GO
--- INSERT Bill :해당하는 테이블에서 계산서 테이블의 데이터를 삽입을 위한 PROC
CREATE PROC USE_InsertBill
@idTable INT --- 매개변수
AS
BEGIN
	INSERT Bill(DateCheckIn ,
		DateCheckOut ,
		idTable ,
		status
	) 
	VALUES (GETDATE() ,
		DATEADD(hour,2,GETDATE()), ---시작하는 시간부터 2시간 뒤에 종료
		@idTable ,
		0 ---기준으로 결제 아직 하는 상태로
	)
END
GO

--- INSERT Bill Info: 해당하는 Bill에서 계산서의 데이터를 산입을 위한 PROC
--- 3경우에 있음: 해당하는 테이블 이미 없거나 있임,있으면 주문 들어 있는 항목들을 체크해서 추가할 수 있도록
CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT ---매개변수
AS
BEGIN
	--- idBill과 idFood를 파악해서 BillInfo에서 이미 존재하는지 검사 
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
		SELECT @isExitsBillInfo = id,@foodCount = bi.count 
		FROM BillInfo AS bi 
		WHERE idBill = @idBill AND idFood = @idFood
	IF(@isExitsBillInfo > 0) --- 계산어 이미 존재하는 경우에는
	BEGIN 
		DECLARE @newCount  INT = @foodCount + @count --- 새로 음식 수량을 계산
		IF(@newCount > 0)
			UPDATE BillInfo SET count = @newCount WHERE idFood = @idFood --- 같은 음식만 수량 증가
		ELSE 
			DELETE BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE --- 이미 존재하 지않는 경우에는 새로 계산서 추가해서 계속 실행
	BEGIN
		INSERT BillInfo (idBill,
			idFood,
			count
		) 
		VALUES (@idBill ,
			@idFood,
			@count
		)
	END
END
GO
--- TRINGGER BillInfo for INSERT,UPDATE :
--- 주문시에서 Bill를 만들어서 BiffInfo 삽입할때 테이블의 상태를 변경해주는 Trigger
CREATE TRIGGER UTG_UpdateBillInfo
ON BillInfo FOR INSERT, UPDATE --- BillInfo테이블에서 Insert과 Update를 일어났을때
AS
BEGIN
	DECLARE @idBill INT 

	SELECT @idBill = idBill FROM Inserted --- insert한 정보부터 idBill의 값을 얻음

	DECLARE @idTable INT    

	SELECT @idTable = idTable FROM Bill WHERE id  = @idBill AND status = 0 --- 주문한 테이블을 id를 얻음

	UPDATE TableFood SET status = 'HAVE' WHERE id = @idTable --- 테이블 상태를 변경

END
GO
--- TRIGGER Bill for UPDATE :
--- 결제시에서 해당하는 테이블의 상태를 변경하기 위해서 Bill의 상태를 변경해주는 Trigger
CREATE TRIGGER UTG_UpdateBill
ON Bill FOR UPDATE --- Bill 테이블에서 Updata를 일어났을때
AS
BEGIN
	DECLARE @idBill INT

    SELECT @idBill = id FROM Inserted --- insert란 정보를 idBill의 값은 얻음

	DECLARE @idTable INT 
    
	SELECT @idTable = idTable FROM Bill WHERE id  = @idBill --- 테이블의 id 값은 얻음

	DECLARE @count INT = 0

	SELECT @count = COUNT(*)FROM Bill WHERE idTable = @idTable AND status = 0

	IF(@count = 0) --- Bill가 없는 경우에는 현재 테이블이 손님이 없는 뜻이 동일
		UPDATE TableFood SET status = 'DONT HAVE' WHERE id = @idTable
END
GO
--- 전체 기준 데이터를 조회
SELECT * FROM dbo.TableFood
SELECT * FROM Account
SELECT * FROM dbo.FoodCategory
SELECT * FROM dbo.Food
SELECT * FROM dbo.Bill
SELECT * FROM BillInfo

