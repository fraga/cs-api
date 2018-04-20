using System;
using Bitprim.Native;

namespace Bitprim
{

    public class HashList : NativeList<byte[]>
    {
        private bool ownsNativeObject_;

        public override IntPtr CreateNativeList()
        {
            ownsNativeObject_ = true;
            return HashListNative.chain_hash_list_construct_default();
        }

        public override byte[] GetNthNativeElement(uint n)
        {
            var managedHash = new hash_t();
            HashListNative.chain_hash_list_nth_out(NativeInstance, (UIntPtr)n, ref managedHash);
            return managedHash.hash;
        }

        public override uint GetCount()
        {
            return (uint) HashListNative.chain_hash_list_count(NativeInstance);
        }

        public override void AddElement(byte[] element)
        {
            HashListNative.chain_hash_list_push_back(NativeInstance, element);
        }

        public override void DestroyNativeList()
        {
            if(ownsNativeObject_)
            {
                //Logger.Log("Destroying hash list " + NativeInstance.ToString("X") + " ...");
                HashListNative.chain_hash_list_destruct(NativeInstance);
                //Logger.Log("Hash list " + NativeInstance.ToString("X") + " destroyed!");
            }
        }

        internal HashList(IntPtr nativeInstance, bool ownsNativeObject = true) : base(nativeInstance)
        {
            ownsNativeObject_ = ownsNativeObject;
        }
    }
    

}