using scotus_scan.Model.ModelMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace scotus_scan.Model
{
    public class Case
    {
        public Case()
        {
            Dockets = new List<string>();
            VoteSplit = VoteResult.Undetermined;
        }

        public string CaseId { get; set; }
        public List<string> Dockets { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime ArgumentDate { get; set; }
        public int Term { get; set; }
        public string Court { get; set; }
        public string CaseName { get; set; }
        public int OpinionWriterId { get; set; }
        public ScotusVoteTotal VoteDetails { get; set; }
        public VoteResult VoteSplit { get; set; }
        public int PartisanDecision { get; set; }

        public static DecisionDirection MapDecisionDirection(int dd)
        {
            switch (dd)
            {
                case 1:
                    return DecisionDirection.Conservative;
                case 2:
                    return DecisionDirection.Liberal;
                case 3:
                default:
                    return DecisionDirection.Unspecified;
            }
        }

        public static LawType MapLawType(int lt)
        {
            switch (lt)
            {
                case 1:
                    return LawType.Constitution;
                case 2:
                    return LawType.ConstitutionalAmendment;
                case 3:
                    return LawType.FederalStatute;
                case 4:
                    return LawType.CourtRules;
                case 5:
                    return LawType.Other;
                case 6:
                    return LawType.InfrequentlyLitigatedStatutes;
                case 7:
                    return LawType.StateLocalLaw;
                case 8:
                default:
                    return LawType.NoLegalProvision;
            }
        }

        public static bool IsMajorityVote(int voteData)
        {
            if(voteData == 2 || voteData == 6 || voteData == 8)
            {
                return false;
            }
            return true;
        }

        public static VoteResult EvalSplit(ScotusVoteTotal voteTotal)
        {
            var conVotes = new List<int>() { 116, 115, 112, 111, 108, 106, 105 }; // Anthony Kenedy is 106
            var libVotes = new List<int>() { 114, 113, 110, 109, 107, 104, 103 };

            if (voteTotal.MinorityCount == 0)
                return VoteResult.Unanimous;
            if (voteTotal.IsEqualVote)
                return VoteResult.Even;

            bool majorityHasLibs = false;
            bool majorityHasCons = false;
            bool minorityHasLibs = false;
            bool minorityHasCons = false;

            foreach (int maj in voteTotal.MajorityVotes)
            {
                // Does it have any libs?
                foreach(int lib in libVotes)
                {
                    if(lib == maj) majorityHasLibs = true;
                }

                foreach(int con in conVotes)
                {
                    if (con == maj) majorityHasCons = true;
                }
            }

            foreach (int maj in voteTotal.MinorityVotes)
            {
                // Does it have any libs?
                foreach (int lib in libVotes)
                {
                    if (lib == maj) minorityHasLibs = true;
                }
                foreach (int con in conVotes)
                {
                    if (con == maj) minorityHasCons = true;
                }
            }

            if (voteTotal.MajorityCount <= 5)
            {
                if (!majorityHasLibs)
                    return VoteResult.TypicalSplit;
                else
                    return VoteResult.NonTypicalSplit;
            }
            else
            {
                if(voteTotal.MinorityCount == 1)
                {
                    return VoteResult.SingleDissent;
                }

                if (minorityHasCons)
                {
                    if (minorityHasLibs)
                        return VoteResult.MixedMinority;
                    else
                        return VoteResult.ConMinority;
                }
                else
                {
                    return VoteResult.LibMinority;
                }
            }
        }
    }

    public enum VoteResult
    {
        TypicalSplit, 
        NonTypicalSplit, 
        ConMinority, 
        LibMinority,
        MixedMinority,
        Unanimous, 
        Even,
        SingleDissent,
        Undetermined
    }

    public class ScotusVoteTotal
    {
        public ScotusVoteTotal()
        {
            MajorityVotes = new List<int>();
            MinorityVotes = new List<int>();
        }

        public string CaseId { get; set; }
        public bool IsEqualVote { get; set; }
        public int MajorityCount { get; set; }
        public int MinorityCount { get; set; }
        public List<int> MajorityVotes { get; set; }
        public List<int> MinorityVotes { get; set; }
        public string MajorityString { get; set; }
        public string MinorityString { get; set; }

        public void ParseVotes()
        {
            MajorityString = "";
            foreach(int jId in MajorityVotes)
            {
                this.MajorityString += JusticeMap.GetJusticeName(jId) + "; ";
            }

            MinorityString = "";
            foreach(int jId in MinorityVotes)
            {
                this.MinorityString += JusticeMap.GetJusticeName(jId) + "; ";
            }
        }

    }

    public class ScotusVote
    {
        public ScotusVote() { }

        public int JusticeId { get; set; }
        public int Vote { get; set; }
        public int Opinion { get; set; }
        public int Majority { get; set; }
    }

    public class Justice
    {
        public Justice(int id)
        {
            this.JusticeId = id;
        }

        public int JusticeId { get; set; }
        public string JusticeName { get; set; }
        public string JusticeImage { get; set; }
    }
    

    public enum DecisionDirection
    {
        Liberal, 
        Conservative,
        Unspecified
    }

    public enum LawType
    {
        Constitution, 
        ConstitutionalAmendment, 
        FederalStatute, 
        CourtRules, 
        Other,
        InfrequentlyLitigatedStatutes,
        StateLocalLaw, 
        NoLegalProvision
    }
}
