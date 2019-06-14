using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scotus_scan.Model
{

    public class ScotusRow
    {
        public ScotusRow() { }

        public string caseId { get; set; }
        public string docketId { get; set; }
        public string caseIssuesId { get; set; }
        public string voteId { get; set; }
        public DateTime dateDecision { get; set; }
        public int decisionType { get; set; }
        public string usCite { get; set; }        
        public string sctCite { get; set; }
        public string ledCite { get; set; }
        public string lexisCite { get; set; }
        public int term { get; set; }
        public int naturalCourt { get; set; }
        public string chief { get; set; }
        public int docket { get; set; }
        public string caseName { get; set; }
        public DateTime dateArgument { get; set; }
        public DateTime dateRearg { get; set; }
        public int petitioner { get; set; }
        public string petitionerState { get; set; }
        public int respondent { get; set; }
        public string respondentState { get; set; }
        public int jurisdiction { get; set; }
        public int adminAction { get; set; }
        public int adminActionState { get; set; }
        public int threeJudgeFdc { get; set; }
        public int caseOrigin { get; set; }
        public int caseOriginState { get; set; }
        public int caseSource { get; set; }
        public int caseSourceState { get; set; }
        public int lcDisagreement { get; set; }
        public int certReason { get; set; }
        public int lcDisposition { get; set; }
        public int lcDispositionDirection { get; set; }
        public int declarationUncon { get; set; }
        public int caseDisposition { get; set; }
        public int caseDispositionUnusual { get; set; }
        public int partyWinning { get; set; }
        public int precedentAlteration { get; set; }
        public int voteUnclear { get; set; }
        public int issue { get; set; }
        public int issueArea { get; set; }
        public int decisionDirection { get; set; }
        public int decisionDirectionDissent { get; set; } 
        public int authorityDecision1 { get; set; }
        public int authorityDecision2 { get; set; }
        public int lawType { get; set; }
        public int lawSupp { get; set; }
        public string lawMinor { get; set; }
        public int majOpinWriter { get; set; }
        public int majOpinAssigner { get; set; }
        public int splitVote { get; set; }
        public int majVotes { get; set; }
        public int minVotes { get; set; }
        public int justice { get; set; }
        public string justiceName { get; set; }
        public int vote { get; set; }
        public int opinion { get; set; }
        public int direction { get; set; }
        public int majority { get; set; }
        public int firstAgreement { get; set; }
        public int secondAgreement { get; set; }

        public void ParseScotusRow(List<string> rowInfo)
        {
            caseId = rowInfo[0];
            docketId = rowInfo[1];
            caseIssuesId = rowInfo[2];
            voteId = rowInfo[3];
            dateDecision = convertDateTimeVal(rowInfo[4]);
            decisionType = convertIntVal(rowInfo[5]);
            usCite = rowInfo[6];
            sctCite = rowInfo[7];
            ledCite = rowInfo[8];
            lexisCite = rowInfo[9];
            term = convertIntVal(rowInfo[10]);
            naturalCourt = convertIntVal(rowInfo[11]);
            chief = rowInfo[12];
            docket = convertIntVal(rowInfo[13]);
            caseName = rowInfo[14];
            dateArgument = convertDateTimeVal(rowInfo[15]);
            dateRearg = convertDateTimeVal(rowInfo[16]);
            petitioner = convertIntVal(rowInfo[17]);
            petitionerState = rowInfo[18];
            respondent = convertIntVal(rowInfo[19]);
            respondentState = rowInfo[20];
            jurisdiction = convertIntVal(rowInfo[21]);
            adminAction = convertIntVal(rowInfo[22]);
            adminActionState = convertIntVal(rowInfo[23]);
            threeJudgeFdc = convertIntVal(rowInfo[24]);
            caseOrigin = convertIntVal(rowInfo[25]);
            caseOriginState = convertIntVal(rowInfo[26]);
            caseSource = convertIntVal(rowInfo[27]);
            caseSourceState = convertIntVal(rowInfo[28]);
            lcDisagreement = convertIntVal(rowInfo[29]);
            certReason = convertIntVal(rowInfo[30]);
            lcDisposition = convertIntVal(rowInfo[31]);
            lcDispositionDirection = convertIntVal(rowInfo[32]);
            declarationUncon = convertIntVal(rowInfo[33]);
            caseDisposition = convertIntVal(rowInfo[34]);
            caseDispositionUnusual = convertIntVal(rowInfo[35]);
            partyWinning = convertIntVal(rowInfo[36]);
            precedentAlteration = convertIntVal(rowInfo[37]);
            voteUnclear = convertIntVal(rowInfo[38]);
            issue = convertIntVal(rowInfo[39]);
            issueArea = convertIntVal(rowInfo[40]);
            decisionDirection = convertIntVal(rowInfo[41]);
            decisionDirectionDissent = convertIntVal(rowInfo[42]);
            authorityDecision1 = convertIntVal(rowInfo[43]);
            authorityDecision2 = convertIntVal(rowInfo[44]);
            lawType = convertIntVal(rowInfo[45]);
            lawSupp = convertIntVal(rowInfo[46]);
            lawMinor = rowInfo[47];
            majOpinWriter = convertIntVal(rowInfo[48]);
            majOpinAssigner = convertIntVal(rowInfo[49]);
            splitVote = convertIntVal(rowInfo[50]);
            majVotes = convertIntVal(rowInfo[51]);
            minVotes = convertIntVal(rowInfo[52]);
            justice = convertIntVal(rowInfo[53]);
            justiceName = rowInfo[54];
            vote = convertIntVal(rowInfo[55]);
            opinion = convertIntVal(rowInfo[56]);
            direction = convertIntVal(rowInfo[57]);
            majority = convertIntVal(rowInfo[58]);
            //firstAgreement = convertIntVal(rowInfo[59]);
            //secondAgreement = convertIntVal(rowInfo[60]);

        }
        private int convertIntVal(string data)
        {
            int maybeInt;
            if (!int.TryParse(data, out maybeInt)) maybeInt= 0;
            return maybeInt;
        }

        private DateTime convertDateTimeVal(string data)
        {
            DateTime maybeDT;
            if (!DateTime.TryParse(data, out maybeDT)) maybeDT = DateTime.MinValue;
            return maybeDT;
        }


    }

    
}
