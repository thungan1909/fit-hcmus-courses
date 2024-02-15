#include "Test.h"

vector<wstring> readOneLineToVector(wifstream& in) {
	wstring currentLine, temp;
	wstringstream ss;
	vector<wstring> result;

	getline(in, currentLine);
	ss << currentLine;
	while (!ss.eof()) {
		getline(ss, temp, L',');
		ss.get();
		result.push_back(temp);
	}

	return result;
}

void readNames(vector<wstring>& firstNames, vector<wstring>& maleMiddleNames, vector<wstring>& maleLastNames, vector<wstring>& femaleMiddleNames, vector<wstring>& femaleLastNames) {
	wifstream in("names.txt");
	in.imbue(std::locale(std::locale::empty(), new std::codecvt_utf8<wchar_t>));

	char check;
	//khi file được encode dưới dạng nào đó, luôn có những kí tự đầu tiên không phải là kí tự đọc được
	while (true) {
		check = in.peek();
		if ((check < 'A' || check > 'z' || (check > 'Z' && check < 'a')) && (check < '0' || check > '9'))
			in.get();
		else
			break;
	}

	firstNames = readOneLineToVector(in);
	maleMiddleNames = readOneLineToVector(in);
	maleLastNames = readOneLineToVector(in);
	femaleMiddleNames = readOneLineToVector(in);
	femaleLastNames = readOneLineToVector(in);

	in.close();
}

void readDomains(vector<string>& domains) {
	freopen("emails.txt", "rt", stdin);
	while (!cin.eof())
	{
		string temp;
		getline(cin, temp);
		domains.push_back(temp);
	}
	cin.clear();
	freopen("CON", "rt", stdin);
}

void readAddress(vector<string>& str, vector<string>& wa, vector<string>& dt) {
	string reader, temp;
	size_t posEnd = 0;

	freopen("HCMADDRESS.txt", "rt", stdin);
	while (!cin.eof())
	{
		getline(cin, reader);
		posEnd = reader.find(",");
		temp = reader.substr(7, posEnd - 7);
		str.push_back(temp);
		reader.erase(0, posEnd + 2);
		posEnd = reader.find(",");
		temp = reader.substr(0, posEnd);
		wa.push_back(temp);
		reader.erase(0, posEnd + 2);
		dt.push_back(reader);
	}
	cin.clear();
	freopen("CON", "rt", stdin);
}

void readCityCodes(vector<string>& cityCodes, vector<string>& cityNames) {
	fstream in("cityCode.txt", ios::in);
	string code, name;
	getline(in, code);	//bỏ dòng đầu
	while (!in.eof()) {
		getline(in, code, ',');
		in.get();
		getline(in, name, '\n');

		cityCodes.push_back(code);
		cityNames.push_back(name);
	}
	in.close();
}