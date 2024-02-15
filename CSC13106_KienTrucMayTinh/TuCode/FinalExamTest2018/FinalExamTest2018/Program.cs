
//Lớp tổng quát cho mọi đối tượng trong hệ thống
public abstract class MEntity
{

    //Tự điền tất cả kiểu dữ liệu trên hệ thống
    protected static Dictionary<string, MEntity> entities = new Dictionary<string, MEntity>();

    protected static int Counter = 0; //Tổng số đối tượng MEntity
    public string ID; //Định danh duy nhất của đối tượng MEntity
    public string ClassName; //Tên của lớp đối tượng, sẽ thay đổi tuỳ theo lớp kế thừa
    

    //Câu 1: Khởi tạo mặc định (Hàm contrustor) cho đối tượng MEntity
    public MEntity()
    {
        //ID là dạng chuỗi phân biệt, xác định bằng phương thức SHA3_512.Hash(Counter++)
        ID = Counter.ToString();
        Counter++;
        ClassName = this.GetType().ToString();

        //Khi đối tượng MEntity được tạo ra, đối tượng này luôn tự đăng ký vào từ điển MEntity.entities
        MEntity.entities.Add(ID, this);

    }
    //Câu 2: Tìm và trả về đối tượng có định danh là ID và đối tượng tên là ClassName.
    //Nếu không có, trả về Null
    public static MEntity FindByID(string ID, string strClassName)
    {
        if (entities.ContainsKey(ID))
        {
            if (entities[ID].ClassName == strClassName)
            {
                return entities[ID];
            }
        }
        return null;
    }

}


//Lớp MAccount
public class MAccount: MEntity
{
    public float Energy; //năng lượng hiện tại của tài khoản để hoạt động trên hệ thống
    //Kiểm tra tài khoản có đủ năng lượng để thực thi 1 thao tác trên hệ thống
    public bool EnoughEnergy(float amount)
    {
        return Energy >= amount;
    }

    //Sử dụng năng lượng để thực thi 1 thao tác trên hệ thống
    public void ConsumeEnergy(float amount)
    {
        Energy -= amount;
    }

    //Nhận thêm năng lượng
    public void SupplyEnergy(float amount)
    {
        Energy += amount;
    }


  
    static public MAccount GetAccount(string ID)
    {
        MEntity res = MEntity.FindByID(ID, "MAccount");
        if (res != null)
        {
            return (MAccount)res;
        }
        return null;
    }
}

//Lớp MType
public class MType: MEntity
{
    static private float energyCreate = 10;
    public string Name; //Tên kiểu dữ liệu
    public List<string> AttributeList = new List<string>(); //Danh sách tên các thuộc tính
    
    //Tìm và ép kiểu MType cho đối tượng có ID cho trước
    static public MType GetType(string ID)
    {
        MEntity res = MEntity.FindByID(ID, "MType");
        if (res != null)
        {
            return (MType)res;
        }
        return null;
    }

    public MType(string _name, List<string> _attributeList) 
    { 
        Name = _name;
        AttributeList = _attributeList;
    }

    //Câu 3: Khởi tạo và đăng ký kiểu dữ liệu mới
    static public string RegisterNewType(string AccountID, string name, List<string> attributeList)
    {
        //Tìm tài khoản MAcount tương ứng AccountID
        MAccount res = MAccount.GetAccount(AccountID);

        //Nếu tài khoản tồn tại 
        if (res != null)
        {
            //Và còn đủ năng lượng tối thiểu
            if (res.EnoughEnergy(energyCreate))
            {
                //Trừ năng lượng vào tài khoản tương ứng
                res.ConsumeEnergy(energyCreate);
                //Tạo ra đối tượng MType
                MType type = new MType(name, attributeList);
                //Trả về ID của đối tượng MType được tạo
                return type.ID;
            }
            //Trả về chuỗi rỗng nếu thực hiện không thành công
            return "";
        }
        return "";
    }
}


// Lớp MObject 
public class MObject : MEntity
{
    static private float energyCreate = 2; //Năng lượng cần khi tạo ra 1 đối tượng dữ liệu
    static private float energyUpdate = 1; //năng lượng cần khi cập nhật 1 đối tượng dữ liệu
    public string TypeID; //ID của kiểu dữ liệu của đối tượng dữ liệu

    //Từ điển các thuộc tính. Giá trị của mỗi thuộc tính được lưu ở kiểu chuỗi.
    public Dictionary<string, string> Attributes = new Dictionary<string, string>();

    //Constructor để tạo ra đối tượng dữ liệu tuong ứng với kiểu hình ảnh là TypeID
    //Câu 4: Cài đặt Contructor cho MObject với TypeID
    protected MObject(string TypeID) : base()
    {
        //Sử dụng phương thức tĩnh MType.GetType() => đối tượng type thuộc lớp MType tương ứng với typeID 
        MType type = MType.GetType(TypeID);

        //Khởi tạo từ điển Attributes chưa đầy đủ thuộc tín từ type.AttributeList.
        List<string> Attributes = type.AttributeList;
    }


    //Tìm tài khoản có định danh AccountID tạo ra đối tượng với kiểu dữ liệu có định danh là TypeID
    static public string CreateNewObject(string AccountID, string TypeID)
    {
        //Tìm tài khoản có định danh AccountID
        MAccount account = MAccount.GetAccount(AccountID);
        if (account != null)
        {
            //Nếu còn đủ năng lượng để tạo
            if (account.EnoughEnergy(energyCreate))
            {
                //Trừ đi năng lượng dùng để tạo
                account.ConsumeEnergy(energyCreate);

                //Tạo đối tượng MObject mới
                MObject mObj =new MObject(TypeID);
                return mObj.TypeID;
            }
            return "";
        }
        return "";
    }

    //Tìm và ép kiểu cho MObject có đối tượng ID cho trước

    static public MObject GetObject (string ID)
    {
        MEntity mEntity = MEntity.FindByID(ID, "MObject");
        if (mEntity != null)
        { 
            return (MObject)mEntity;
        }
        return null;
    }

    //Lấy giá trị hoặc cập nhật thuộc tính có tên là strAttributeName
    //Câu 5:
    public string this[string strAttributeName]
    {
        //Lấy giá trị thuộc tính
        get
        {
            if (Attributes.ContainsKey(strAttributeName))
            {
                return Attributes[strAttributeName];
            }
            return "";
        }

       
        
        set
        {
            //Nếu tồn tại thuộc tính
            if (Attributes.ContainsKey(strAttributeName))
            {
                //Nếu giá trị có thay đổi
                if (Attributes[strAttributeName] != value)
                {
                    //Cập nhật thành giá trị mới
                    Attributes[strAttributeName] = value;
                }
            }
            //Nếu không tồn tại thuộc tính
            else
            {
                //Bổ sung thuộc tính mới vào từ điển
                MType mType = MType.GetType(TypeID);
                mType.AttributeList.Add(strAttributeName);
                //Gán giá trị vào
                Attributes.Add(strAttributeName, value);
            }

            //Câu 8: Tự động thông báo khi đồng bộ hoá dữ liệu
            //Luôn tự động gọi phương thức UpdateObject() của lớp DecentralizeAppEngine
            DecentralizeAppEngine.UpdateObject(this.ID);

        }
    }

}

//Lớp MTransaction
public abstract class MTransaction: MEntity
{
    static private float energyCreate = 5; //năng lượng cần khi đăng ký 1 giao tác
    static private float energyInvoke = 1; //năng lượng cần khi thực thi 1 giao tác

    //Tìm và trả về giao tác MTransaction trong từ điển có định danh là ID
    // Nếu không có trả về null
    static public MTransaction GetTransaction(string TransactionID)
    {
        MEntity mEntity = MEntity.FindByID(TransactionID, "MTransaction");
        if (mEntity != null)
        {
            return (MTransaction)mEntity;
        }
        return null;
    }
    //Tài khoản có định danh là AccountID đăng ký 1 giao tác Transaction. 
    //Kết quả trả về là ID của Transaction
    static public string RegisterTransaction (string AccountID, MTransaction Transaction)
    {
        //Tìm tài khoản có Account ID tương ứng
        MAccount mAccount = MAccount.GetAccount(AccountID);
        if (mAccount != null)
        {
            if(mAccount.EnoughEnergy(energyCreate))
            {
                mAccount.ConsumeEnergy(energyCreate);
                return Transaction.ID;
            }
            return null;
        }
        return null;
    }

    //Tài khoản có định danh là AccountID thực thi giao tác
    //Mảng input chứa danh sách các tham số đầu vào
    public MObject InvokeTransaction(string AccountID, string[] input)
    {
        MAccount mAccount = MAccount.GetAccount(AccountID);
        if (mAccount != null)
        {
           if (mAccount.EnoughEnergy(energyInvoke))
            {
                mAccount.ConsumeEnergy(energyInvoke);
                MObject result = Execute(AccountID, input);
                return result;
            }
            return null;
        }
        return null;

    }
    
    
    //Phương thức nội bộ để xử lý giao tác. Tài khoản thực thi giao tác có định danh là AccountID
    //Mảng input chứa danh sách các tham số đầu vào
    protected abstract MObject Execute (string AccountID, string[] input);

}
public class DangKyHocPhan: MTransaction
{
    protected override MObject Execute(string AccountID, string[] input)
    {
        string TypeID_DKHP = "0x20180105afebcc817123fa82bc"; // Gán giá trị chuỗi vào TypeID_DKHP
        string SinhVienID = input[0]; // Gán giá trị string của input[0] vào SinhVienID
        string MonHocID = input[1]; // Gán giá trị string của input[1] vào MonHocID
        int sttLop = int.Parse(input[2]); // Convert MonHocID từ string sang int
        int HocKy = int.Parse(input[3]); // Convert input[3] từ string sang int cho biến HocKy
        string NamHoc = input[4]; // Gán giá trị string của input[0] vào NamHoc
        MObject sinhvien = MObject.GetObject(SinhVienID); // Tìm Object sinh viên bằng SinhVienID
        if (sinhvien == null) return null; // Nếu tìm không thành công thì return Null
        MObject monhoc = MObject.GetObject(MonHocID); // Tìm Object monhoc bằng MonHocID
        if (monhoc == null) return null; // Nếu tìm không thành công thì return Null
        int SiSoToiDa = int.Parse(monhoc["SiSoToiDa"]); // Convert giá trị monhoc["SiSoToiDa"] từ string sang int cho biến SiSoToiDa
        int SiSoHienTai = int.Parse(monhoc["SiSoHienTai"]); // Convert giá trị monhoc["SiSoHienTai"] từ string sang int cho biến SiSoHienTai
        if (SiSoHienTai < SiSoToiDa) // Nếu SiSoHienTai < SiSoToiDa thì ta vào vòng if (Đăng kí học phần)
        {
            monhoc["SiSoHienTai"] = (SiSoHienTai + 1).ToString(); // gán giá trị monhoc["SiSoHienTai"] = SiSoHienTai + 1
            string ObjectID_DKHP = MObject.CreateNewObject(AccountID, TypeID_DKHP); // Tạo Object mới với (AccountID, TypeID_HKHP) và trả ra ID
            MObject dkhp = MObject.GetObject(ObjectID_DKHP);// Tìm Object dkph
            dkhp["MaSV"] = sinhvien["MaSV"]; // Gán giá trị dkhp["MaSV"] = sinhvien["MaSV"]
            dkhp["MaMH"] = monhoc["MaMH"]; // Gán giá trị dkhp["MaMH"] = monhoc["MaMH"]
            dkhp["STTLop"] = sttLop.ToString(); // Gán giá trị dkhp["STTLop"] = sttLop
            dkhp["HocKy"] = NamHoc; // Gán giá trị dkhp["HocKy"] = NamHoc
            return dkhp; // trả ra dkhp
        }
        return null; // SiSoHienTai >= SiSoToiDa
    }
}

//Lớp MNode Được cài đặt sẵn để xử lý tính toán trong hệ thống
public class MNode
{
    public static void SynchoronizeObject( string ID)
    {
        
    }
    public MObject ProcesMTransaction(string AccountID, string TransactionID, string[] input)
    {
        return null;
    }
}

public class DecentralizeAppEngine
{
    //Tự điền toàn bộ các node xử lý và lưu trữ hệ thống
    private static Dictionary<string, MNode> nodes = new Dictionary<string, MNode>();
    //Yêu cầu xử lý giao tác có ID là TransactionID, tài khoản chọn thực hiện có ID là AccountID, các tham số là input
    //Giao tác được xử lý trên toàn bộ các node, từ đó chọn kết quả thống nhất và trả về định danh
    public  string ProcesMTransaction(string AccountID, string TransactionID, string[] input)
    {
        List <MObject> canđiates = new List <MObject> ();
        foreach (string nodeID in nodes.Keys)
        {
            MObject localResult = nodes[nodeID].ProcesMTransaction(
                AccountID, TransactionID, input);
            canđiates.Add (localResult);
        }
        MObject result = FindMostReliableResult(canđiates);
        if (result == null) return "";
        return result.ID;
    }

    //Tìm đối tượng dữ liệu thống nhất cao nhất trong danh sách candidates
    private static MObject FindMostReliableResult(List<MObject> candidates)
    {
        if (candidates == null)
        {
            return null;
        }

        int mostVoted = 0, index = 0, n = candidates.Count;
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
                if (candidates[i].ID == candidates[j].ID)
                    count++;
            if (count > mostVoted)
            {
                mostVoted = count;
                index = i;
            }
        }
        return candidates[index];
    }
    
    //Yêu cầu cập nhật đối tượng có dữ liệu có ID là ObjectID trên toàn bộ các node
    //Câu 9: Cài đặt phương thức UpdateObject để cập nhật thông tin đối tượng  trên tất cả các node
    public static void UpdateObject (string ObjectID)
    {
        foreach (var node in nodes)
        {
            if (node.Key == ObjectID)
            {
                MNode.SynchoronizeObject(ObjectID); break;
            }
        } 
            

    }
}