﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace InterviewQuestions
{
    public class Question1_CodonTranslationXmlTester : CodonTranslationTester
    {
        protected override string CodonTableFileName
        {
            get { return "CodonTable.xml"; }
        }
    }

    public class Question2_CodonTranslationJsonTester : CodonTranslationTester
    {
        protected override string CodonTableFileName
        {
            get { return "CodonTable.json"; }
        }
    }

    public class Question3_CodonTranslationCsvTester : CodonTranslationTester
    {
        protected override string CodonTableFileName
        {
            get { return "CodonTable.csv"; }
        }
    }

    [TestFixture]
    public abstract class CodonTranslationTester
    {
        private CodonTranslator codonTranslator;

        private string sample = @"
     ATGA CACAGCTTCA GATTTCATTA TTGCTGACAG
     CTACTATATC ACTACTCCAT CTAGTAGTGG CCACGCCCTA TGAGGCATAT CCTATCGGAA
     AACAATACCC CCCAGTGGCA AGAGTCAATG AATCGTTTAC ATTTCAAATT TCCAATGATA
     CCTATAAATC GTCTGTAGAC AAGACAGCTC AAATAACATA CAATTGCTTC GACTTACCGA
     GCTGGCTTTC GTTTGACTCT AGTTCTAGAA CGTTCTCAGG TGAACCTTCT TCTGACTTAC
     TATCTGATGC GAACACCACG TTGTATTTCA ATGTAATACT CGAGGGTACG GACTCTGCCG
     ACAGCACGTC TTTGAACAAT ACATACCAAT TTGTTGTTAC AAACCGTCCA TCCATCTCGC
     TATCGTCAGA TTTCAATCTA TTGGCGTTGT TAAAAAACTA TGGTTATACT AACGGCAAAA
     ACGCTCTGAA ACTAGATCCT AATGAAGTCT TCAACGTGAC TTTTGACCGT TCAATGTTCA
     CTAACGAAGA ATCCATTGTG TCGTATTACG GACGTTCTCA GTTGTATAAT GCGCCGTTAC
     CCAATTGGCT GTTCTTCGAT TCTGGCGAGT TGAAGTTTAC TGGGACGGCA CCGGTGATAA
     ACTCGGCGAT TGCTCCAGAA ACAAGCTACA GTTTTGTCAT CATCGCTACA GACATTGAAG
     GATTTTCTGC CGTTGAGGTA GAATTCGAAT TAGTCATCGG GGCTCACCAG TTAACTACCT
     CTATTCAAAA TAGTTTGATA ATCAACGTTA CTGACACAGG TAACGTTTCA TATGACTTAC
     CTCTAAACTA TGTTTATCTC GATGACGATC CTATTTCTTC TGATAAATTG GGTTCTATAA
     ACTTATTGGA TGCTCCAGAC TGGGTGGCAT TAGATAATGC TACCATTTCC GGGTCTGTCC
     CAGATGAATT ACTCGGTAAG AACTCCAATC CTGCCAATTT TTCTGTGTCC ATTTATGATA
     CTTATGGTGA TGTGATTTAT TTCAACTTCG AAGTTGTCTC CACAACGGAT TTGTTTGCCA
     TTAGTTCTCT TCCCAATATT AACGCTACAA GGGGTGAATG GTTCTCCTAC TATTTTTTGC
     CTTCTCAGTT TACAGACTAC GTGAATACAA ACGTTTCATT AGAGTTTACT AATTCAAGCC
     AAGACCATGA CTGGGTGAAA TTCCAATCAT CTAATTTAAC ATTAGCTGGA GAAGTGCCCA
     AGAATTTCGA CAAGCTTTCA TTAGGTTTGA AAGCGAACCA AGGTTCACAA TCTCAAGAGC
     TATATTTTAA CATCATTGGC ATGGATTCAA AGATAACTCA CTCAAACCAC AGTGCGAATG
     CAACGTCCAC AAGAAGTTCT CACCACTCCA CCTCAACAAG TTCTTACACA TCTTCTACTT
     ACACTGCAAA AATTTCTTCT ACCTCCGCTG CTGCTACTTC TTCTGCTCCA GCAGCGCTGC
     CAGCAGCCAA TAAAACTTCA TCTCACAATA AAAAAGCAGT AGCAATTGCG TGCGGTGTTG
     CTATCCCATT AGGCGTTATC CTAGTAGCTC TCATTTGCTT CCTAATATTC TGGAGACGCA
     GAAGGGAAAA TCCAGACGAT GAAAACTTAC CGCATGCTAT TAGTGGACCT GATTTGAATA
     ATCCTGCAAA TAAACCAAAT CAAGAAAACG CTACACCTTT GAACAACCCC TTTGATGATG
     ATGCTTCCTC GTACGATGAT ACTTCAATAG CAAGAAGATT GGCTGCTTTG AACACTTTGA
     AATTGGATAA CCACTCTGCC ACTGAATCTG ATATTTCCAG CGTGGATGAA AAGAGAGATT
     CTCTATCAGG TATGAATACA TACAATGATC AGTTCCAATC CCAAAGTAAA GAAGAATTAT
     TAGCAAAACC CCCAGTACAG CCTCCAGAGA GCCCGTTCTT TGACCCACAG AATAGGTCTT
     CTTCTGTGTA TATGGATAGT GAACCAGCAG TAAATAAATC CTGGCGATAT ACTGGCAACC
     TGTCACCAGT CTCTGATATT GTCAGAGACA GTTACGGATC ACAAAAAACT GTTGATACAG
     AAAAACTTTT CGATTTAGAA GCACCAGAGA AGGAAAAACG TACGTCAAGG GATGTCACTA
     TGTCTTCACT GGACCCTTGG AACAGCAATA TTAGCCCTTC TCCCGTAAGA AAATCAGTAA
     CACCATCACC ATATAACGTA ACGAAGCATC GTAACCGCCA CTTACAAAAT ATTCAAGACT
     CTCAAAGCGG TAAAAACGGA ATCACTCCCA CAACAATGTC AACTTCATCT TCTGACGATT
     TTGTTCCGGT TAAAGATGGT GAAAATTTTT GCTGGGTCCA TAGCATGGAA CCAGACAGAA
     GACCAAGTAA GAAAAGGTTA GTAGATTTTT CAAATAAGAG TAATGTCAAT GTTGGTCAAG
     TTAAGGACAT TCACGGACGC ATCCCAGAAA TGCTGTGATT ATACGCAACG ATATTTTGCT
     TAATTTTATT TTCCTGTTTT ATTTTTTATT AGTGGTTTAC AGATACCCTA TATTTTATTT
     AGTTTTTATA CTTAGAGACA TTTAATTTTA ATTCCATTCT TCAAATTTCA TTTTTGCACT".Replace("\r\n", "").Replace("\t", "").Replace(" ", "");

        protected abstract string CodonTableFileName { get; }

        [SetUp]
        public void Setup()
        {
            codonTranslator = new CodonTranslator(CodonTableFileName);
        }

        [Test]
        public void CanTranslateWithOnlyStartAndStop()
        {
            const string inputDna = "ATGTAA";
            const string expected = "M";

            var actual = codonTranslator.Translate(inputDna);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateOneCodon()
        {
            const string inputDna = "ATGCATTAA";
            const string expected = "MH";

            var actual = codonTranslator.Translate(inputDna);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateOneCodonWithBeginningAndEndingJunk()
        {
            const string dna = "GAACAAATGCATTAATACAAAAA";
            const string expected = "MH";

            var actual = codonTranslator.Translate(dna);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateThreeCodons()
        {
            const string dna = "ATGCATGCGAAGTAA";
            const string expected = "MHAK";

            var actual = codonTranslator.Translate(dna);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateWithMethionineTwice()
        {
            const string dna = "ATGCATGCGAAGATGTAA";
            const string expected = "MHAKM";

            var actual = codonTranslator.Translate(dna);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateOffBalancedStart()
        {
            const string inputDna = "GGATGCATTAA";
            const string expected = "MH";

            var actual = codonTranslator.Translate(inputDna);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateYeast_AXL2()
        {
            var expected = @"MTQLQISLLLTATISLLHLVVATPYEAYPIGKQYPPVARVNESF
                     TFQISNDTYKSSVDKTAQITYNCFDLPSWLSFDSSSRTFSGEPSSDLLSDANTTLYFN
                     VILEGTDSADSTSLNNTYQFVVTNRPSISLSSDFNLLALLKNYGYTNGKNALKLDPNE
                     VFNVTFDRSMFTNEESIVSYYGRSQLYNAPLPNWLFFDSGELKFTGTAPVINSAIAPE
                     TSYSFVIIATDIEGFSAVEVEFELVIGAHQLTTSIQNSLIINVTDTGNVSYDLPLNYV
                     YLDDDPISSDKLGSINLLDAPDWVALDNATISGSVPDELLGKNSNPANFSVSIYDTYG
                     DVIYFNFEVVSTTDLFAISSLPNINATRGEWFSYYFLPSQFTDYVNTNVSLEFTNSSQ
                     DHDWVKFQSSNLTLAGEVPKNFDKLSLGLKANQGSQSQELYFNIIGMDSKITHSNHSA
                     NATSTRSSHHSTSTSSYTSSTYTAKISSTSAAATSSAPAALPAANKTSSHNKKAVAIA
                     CGVAIPLGVILVALICFLIFWRRRRENPDDENLPHAISGPDLNNPANKPNQENATPLN
                     NPFDDDASSYDDTSIARRLAALNTLKLDNHSATESDISSVDEKRDSLSGMNTYNDQFQ
                     SQSKEELLAKPPVQPPESPFFDPQNRSSSVYMDSEPAVNKSWRYTGNLSPVSDIVRDS
                     YGSQKTVDTEKLFDLEAPEKEKRTSRDVTMSSLDPWNSNISPSPVRKSVTPSPYNVTK
                     HRNRHLQNIQDSQSGKNGITPTTMSTSSSDDFVPVKDGENFCWVHSMEPDRRPSKKRL
                     VDFSNKSNVNVGQVKDIHGRIPEML"
                    .Replace("\r\n", "").Replace("\t", "").Replace(" ", "");

            var result = codonTranslator.Translate(sample);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CanTranslateOffBalancedYeast_AXL2()
        {
            var expected = @"MTQLQISLLLTATISLLHLVVATPYEAYPIGKQYPPVARVNESF
                     TFQISNDTYKSSVDKTAQITYNCFDLPSWLSFDSSSRTFSGEPSSDLLSDANTTLYFN
                     VILEGTDSADSTSLNNTYQFVVTNRPSISLSSDFNLLALLKNYGYTNGKNALKLDPNE
                     VFNVTFDRSMFTNEESIVSYYGRSQLYNAPLPNWLFFDSGELKFTGTAPVINSAIAPE
                     TSYSFVIIATDIEGFSAVEVEFELVIGAHQLTTSIQNSLIINVTDTGNVSYDLPLNYV
                     YLDDDPISSDKLGSINLLDAPDWVALDNATISGSVPDELLGKNSNPANFSVSIYDTYG
                     DVIYFNFEVVSTTDLFAISSLPNINATRGEWFSYYFLPSQFTDYVNTNVSLEFTNSSQ
                     DHDWVKFQSSNLTLAGEVPKNFDKLSLGLKANQGSQSQELYFNIIGMDSKITHSNHSA
                     NATSTRSSHHSTSTSSYTSSTYTAKISSTSAAATSSAPAALPAANKTSSHNKKAVAIA
                     CGVAIPLGVILVALICFLIFWRRRRENPDDENLPHAISGPDLNNPANKPNQENATPLN
                     NPFDDDASSYDDTSIARRLAALNTLKLDNHSATESDISSVDEKRDSLSGMNTYNDQFQ
                     SQSKEELLAKPPVQPPESPFFDPQNRSSSVYMDSEPAVNKSWRYTGNLSPVSDIVRDS
                     YGSQKTVDTEKLFDLEAPEKEKRTSRDVTMSSLDPWNSNISPSPVRKSVTPSPYNVTK
                     HRNRHLQNIQDSQSGKNGITPTTMSTSSSDDFVPVKDGENFCWVHSMEPDRRPSKKRL
                     VDFSNKSNVNVGQVKDIHGRIPEML"
                    .Replace("\r\n", "").Replace("\t", "").Replace(" ", "");

            var result = codonTranslator.Translate("AACGT" + sample);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
