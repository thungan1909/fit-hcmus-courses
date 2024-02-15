#include "TelephoneMock.h"

Telephone TelephoneMock::next()
{
	int index = _rng.nextInt(_supportedNetworks.size());
	MobileNetwork network = _supportedNetworks[index];

	vector<string> prefixes = network.prefixes();
	index = _rng.nextInt(prefixes.size());
	string prefix = prefixes[index];

	string numbers = "";
	for (int i = 0; i <= 7; i++) {
		numbers += (_rng.nextInt(10) + '0');
	}

	Telephone result(network, prefix, numbers);
	return result;
}

TelephoneMock::TelephoneMock()
{
	_supportedNetworks = {
	MobileNetwork("Viettel", { "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039" }),
	MobileNetwork("Vinaphone", { "088", "091", "094", "083", "084", "085", "081", "082" }),
	MobileNetwork("Mobiphone", { "089", "090", "093", "070", "079", "077", "076", "078" }),
	MobileNetwork("Vietnamobile", { "092", "056", "058" }),
	MobileNetwork("GMobile", { "099", "059" }),
	MobileNetwork("Itelecom", { "087" })
	};
}
