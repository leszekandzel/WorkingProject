﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class GoogleLanguageDetector : IGoogleLanguageDetector   
    {
        private ICultureInfoProvider cultureInfoProvider;

        public GoogleLanguageDetector(ICultureInfoProvider cultureInfoProvider)
        {
            this.cultureInfoProvider = cultureInfoProvider;
        }

        public GoogleLanguage GetGoogleLanguage()
        {
            var cultureInfo = this.cultureInfoProvider.GetCultureInfo();
            switch (cultureInfo.TwoLetterISOLanguageName) 
            {
                case "de":
                    return new GoogleLanguage("de", "German");

                case "fr":
                    return new GoogleLanguage("fr", "French");

                case "pl":
                    return new GoogleLanguage("pl", "Polish");

                default:
                return new GoogleLanguage("en", "English");
            }
        }

        // possible options are:
        //	af	Afrikaans
        //	sq	Albanian
        //	am	Amharic
        //	ar	Arabic
        //	hy	Armenian
        //	az	Azerbaijani
        //	eu	Basque
        //	be	Belarusian
        //	bn	Bengali
        //	bs	Bosnian
        //	bg	Bulgarian
        //	my	Burmese
        //	ca	Catalan
        //	zh	Chinese
        //	zh-CN	Chinese (Simplified)
        //	zh-HK	Chinese (Hong Kong)
        //	zh-TW	Chinese (Traditional)
        //	hr	Croatian
        //	cs	Czech
        //	da	Danish
        //	nl	Dutch
        //	en	English
        //	en-AU	English (Australian)
        //	en-GB	English (Great Britain)
        //	et	Estonian
        //	fa	Farsi
        //	fi	Finnish
        //	fil	Filipino
        //	fr	French
        //	fr-CA	French (Canada)
        //	gl	Galician
        //	ka	Georgian
        //	de	German
        //	el	Greek
        //	gu	Gujarati
        //	iw	Hebrew
        //	hi	Hindi
        //	hu	Hungarian
        //	is	Icelandic
        //	id	Indonesian
        //	it	Italian
        //	ja	Japanese
        //	kn	Kannada
        //	kk	Kazakh
        //	km	Khmer
        //	ko	Korean
        //	ky	Kyrgyz
        //	lo	Lao
        //	lv	Latvian
        //	lt	Lithuanian
        //	mk	Macedonian
        //	ms	Malay
        //	ml	Malayalam
        //	mr	Marathi
        //	mn	Mongolian
        //	ne	Nepali
        //	no	Norwegian
        //	pl	Polish
        //	pt	Portuguese
        //	pt-BR	Portuguese (Brazil)
        //	pt-PT	Portuguese (Portugal)
        //	pa	Punjabi
        //	ro	Romanian
        //	ru	Russian
        //	sr	Serbian
        //	si	Sinhalese
        //	sk	Slovak
        //	sl	Slovenian
        //	es	Spanish
        //	es-419	Spanish (Latin America)
        //	sw	Swahili
        //	sv	Swedish
        //	ta	Tamil
        //	te	Telugu
        //	th	Thai
        //	tr	Turkish
        //	uk	Ukrainian
        //	ur	Urdu
        //	uz	Uzbek
        //	vi	Vietnamese
        //	zu	Zulu

    }
}
