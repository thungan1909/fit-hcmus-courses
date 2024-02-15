#include "EmailMock.h"

string EmailMock::next()
{
	bool male = _rng.nextInt(2) == 1;
	FullName name = _nameStore.next(male);
	string email = next(name);
	return email;
}

EmailMock::EmailMock(vector<string> domains, FullNameMock nameMock)
{
	_domains = domains;
	_nameStore = nameMock;
}

string EmailMock::next(FullName name)
{
	//Lay 2 ki tu dau cua ho va ten lot

	string first = Util::removeVietnameseSign(name.firstName().substr(0, 1));
	string middle = Util::removeVietnameseSign(name.middleName().substr(0, 1));

	//Chon ngau nhien 1 domain
	int i = _rng.nextInt(_domains.size());
	string domain = _domains[i];

	stringstream writer;
	wstring domainTemp;
	writer << first << middle << Util::removeVietnameseSign(name.lastName()) << "@" << domain;
	string email = writer.str();
	transform(email.begin(), email.end(), email.begin(), [](unsigned char c)
		{ return std::tolower(c); });
	return email;
}
