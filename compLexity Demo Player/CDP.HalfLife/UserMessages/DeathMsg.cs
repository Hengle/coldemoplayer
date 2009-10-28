﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CDP.HalfLife.UserMessages
{
    public class DeathMsg : UserMessage
    {
        public override string Name
        {
            get { return "DeathMsg"; }
        }

        public override bool CanSkipWhenWriting
        {
            get { return true; }
        }

        public byte KillerSlot { get; set; }
        public byte VictimSlot { get; set; }
        public bool Headshot { get; set; }
        public string WeaponName { get; set; }

        public override void Read(BitReader buffer)
        {
            KillerSlot = buffer.ReadByte();
            VictimSlot = buffer.ReadByte();
            Headshot = buffer.ReadByte() == 1;
            WeaponName = buffer.ReadString();
        }

        public override void  Write(BitWriter buffer)
        {
            buffer.WriteByte(KillerSlot);
            buffer.WriteByte(VictimSlot);
            buffer.WriteByte((byte)(Headshot ? 1 : 0));
            buffer.WriteString(WeaponName);
        }

        public override void Log(StreamWriter log)
        {
            log.WriteLine("KillerSlot: {0}", KillerSlot);
            log.WriteLine("VictimSlot: {0}", VictimSlot);
            log.WriteLine("Headshot: {0}", Headshot);
            log.WriteLine("WeaponName: {0}", WeaponName);
        }
    }
}
