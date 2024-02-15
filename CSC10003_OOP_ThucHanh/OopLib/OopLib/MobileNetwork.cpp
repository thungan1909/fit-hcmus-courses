#include "MobileNetwork.h"

string MobileNetwork::name()
{
    return _name;
}

vector<string> MobileNetwork::prefixes()
{
    return _prefixes;
}

MobileNetwork::MobileNetwork()
{
    _name = "";
}

MobileNetwork::MobileNetwork(string name, vector<string> pre)
{
    _name = name;
    _prefixes = pre;
}
