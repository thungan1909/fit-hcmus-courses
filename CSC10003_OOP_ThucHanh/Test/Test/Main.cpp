#include "Test.h"

int main() {
	int ceiling, floor;
	Random r;

	cout << "\nDEMO RANDOM:\n ";
	system("pause");
	cout << "\n=> Xuat ra 1 so ngau nhien: " << r.nextInt() << "\n\n";
	do {
		cout << "Nhap ceiling (de random 1 so trong khoang [0; ceiling)): ";
		cin >> ceiling;
		cout << endl;
		if (ceiling <= 0)
			cout << "Nhap so lon hon 0!\n";
	} while (ceiling <= 0);
	cout << "=> So ngau nhien tu 0 toi " << ceiling - 1 << " la: " << r.nextInt(ceiling) << "\n\n";
	do {
		cout << "Nhap floor va ceiling (de random 1 so trong khoang [floor; ceiling]): ";
		cin >> floor >> ceiling;
		if (ceiling < floor)
			cout << "\nLUU Y: Floor phai nho hon Ceiling. Hay nhap lai !\n";
	} while (ceiling < floor);
	cout << "=> So ngau nhien tu " << floor << " toi " << ceiling << " la : " << r.nextInt(floor, ceiling) << endl;

	cout << "\n===========================\n";
	cout << "\nDEMO DICE: \n";
	system("pause");
	Dice d;
	cout << "\n=> Ket qua gieo xuc xac: " << d.roll() << endl;

	cout << "\n===========================\n";
	cout << "\nDEMO INTEGER: \n";
	system("pause");
	cout << "\nNhap 2 so de tinh uoc chung cua no: ";
	cin >> floor >> ceiling;
	cout << "=> UCLN cua " << floor << " va " << ceiling << " la: " << Integer::gcd(floor, ceiling) << "\n\n";

	cout << "\n===========================\n";
	cout << "\nDEMO RANDOM YEAR: \n";
	system("pause");
	cout << endl;
	RandomYear ry;
	ry.showYears();
	cout << "\n\n";
	cout << "\n===========================\n";

	cout << "\nDEMO ENGLISH VOCABULARY \n";
	system("pause");
	EnglishVocabulary vocabulary;
	cout << "\nNhan enter de hien thi mot cap tu Anh - Viet ngau nhien voi chu de Environment \n(nhan mot ki tu bat ki de dung):\n";
	while (cin.get() == '\n')
		vocabulary.learnVocabulary();

	cout << "\n===========================\n";
	cout << "\nDEMO RANDOM FRACTION:\n ";
	system("pause");
	int n = r.nextInt(5, 20);
	cout << "\n=> Phat sinh ngau nhien 1 so nguyen n. Do la: " << n << endl;
	cout << "=> Co " << n << " phan so duoc tao ra. Do la:\n" << endl;
	Fraction fraction;
	Fraction result;
	for (int i = 0; i < n; i++)
	{
		fraction.setterFraction(fraction.randomFraction());
		cout << fraction << " ";
		result = result + fraction;
		result.reduceFraction();
	}
	cout << "\n=> Tong cac phan so da phat sinh: " << result << "\n\n";

	cout << "\n===========================\n";
	cout << "\nDEMO DYNAMIC ARRAY: \n ";
	system("pause");
	cout << endl;
	DynamicArray arr;
	arr.input();
	cout << "\n=> Mang vua nhap la: ";
	arr.output();

	cout << "\n\n=> Kich thuoc mang: " << arr.length() << endl;
	cout << "=> Phan tu dau: " << arr.getElement(0) << endl;
	cout << "=> Phan tu cuoi: " << arr.getElement(arr.length() - 1) << endl;

	int i, val;
	cout << "\nNhap vi tri phan tu ban muon thay doi: ";
	cin >> i;
	while (i < 0 || i >= arr.length()) {
		cout << "Khong co vi tri " << i << ", moi ban nhap lai: ";
		cin >> i;
	}
	cout << "Nhap gia tri moi: ";
	cin >> val;
	arr.setElement(i, val);
	cout << "\n=> Mang sau khi duoc thay doi: ";
	arr.output();

	cout << "\n===========================\n";
	cout << "\nDEMO TELEPHONE MOCK: \n ";
	system("pause");
	cout << "\n=> Xuat ra 20 so dien thoai ngau nhien: " << endl;

	TelephoneMock telemock;
	for (int i = 0; i < 20; i++)
		cout << telemock.next().toString() << endl;
	cout << endl;

	cout << "\n===========================\n";
	cout << "\nDEMO FULLNAMEMOCK: \n ";
	system("pause");
	_setmode(_fileno(stdout), _O_U16TEXT);
	wcout << L"\n=> Xuat ra 10 ten nam ngau nhien: " << endl;
	wcout.clear();
	vector<wstring> firstNames, maleMiddleNames, maleLastNames, femaleMiddleNames, femaleLastNames;
	readNames(firstNames, maleMiddleNames, maleLastNames, femaleMiddleNames, femaleLastNames);
	FullNameMock nameMock(firstNames, maleMiddleNames, maleLastNames, femaleMiddleNames, femaleLastNames);
	for (int i = 0; i < 10; i++)
		wcout << nameMock.next(true).toString() << endl;

	wcout << L"\n=> Xuat ra 10 ten nu ngau nhien: " << endl;
	for (int i = 0; i < 10; i++)
		wcout << nameMock.next(false).toString() << endl;

	_setmode(_fileno(stdout), _O_TEXT);

	cout << "\n===========================\n";
	cout << "\nDEMO EMAILMOCK: \n ";
	system("pause");
	wcout << "\n=> Xuat ra 10 email ngau nhien: " << endl;
	vector<string> domains;
	readDomains(domains);
	EmailMock emailMock(domains, nameMock);
	for (int i = 0; i < 10; i++) {
		cout << emailMock.next() << endl;
	}

	cout << "\n===========================\n";
	cout << "\nDEMO HCMADDRESSMOCK: \n";
	system("pause");
	cout << "\n=> Xuat ra 10 dia chi ngau nhien: " << endl;
	vector<string> streets, wards, districts;
	readAddress(streets, wards, districts);
	HcmAddressMock addressStore(streets, wards, districts);
	for (int i = 0; i <= 10; i++) {
		Address address = addressStore.next();
		cout << address.toString() << endl;
	}
	cout << "\n===========================\n";
	cout << "\nDEMO BIRTHDAYMOCK:\n ";
	system("pause");
	cout << "\n=> Xuat ra 10 ngay sinh ngau nhien: " << endl;
	BirthDayMock birthdayStore;
	for (int i = 1; i <= 10; i++) {
		DateTime dob = birthdayStore.next();
		cout << dob.toString() << endl;
	}
	cout << "\n===========================\n";
	cout << "\nDEMO CITIZENIDMOCK: \n ";
	system("pause");
	cout << "\n=> Xuat ra 10 cmnd ngau nhien: " << endl;
	vector<string> cityCodes, cityNames;
	readCityCodes(cityCodes, cityNames);
	CitizenIdMock citizenIdStore(cityCodes, cityNames);
	for (int i = 1; i <= 10; i++) {
		string citizenId = citizenIdStore.next();
		cout << citizenId << " | City name: " << citizenIdStore.lookUp(citizenId.substr(0, 3)) << endl;
	}

	return 0;
}