window.projectRadar = (() => {
    let initialized = false;

    const isFileDrag = (event) => {
        const types = event.dataTransfer?.types;
        return types && Array.from(types).includes("Files");
    };

    const preventBrowserFileOpen = (event) => {
        if (isFileDrag(event)) {
            event.preventDefault();
        }
    };

    const initializeDragDrop = (dropZoneId, inputId) => {
        const dropZone = document.getElementById(dropZoneId);
        const input = document.getElementById(inputId);
        if (!dropZone || !input) return;

        if (!initialized) {
            document.addEventListener("dragover", preventBrowserFileOpen, false);
            document.addEventListener("drop", preventBrowserFileOpen, false);
            initialized = true;
        }

        const showActive = (event) => {
            if (!isFileDrag(event)) return;
            event.preventDefault();
            dropZone.classList.add("is-dragging");
            if (event.dataTransfer) event.dataTransfer.dropEffect = "copy";
        };

        const clearActive = (event) => {
            if (isFileDrag(event)) event.preventDefault();
            dropZone.classList.remove("is-dragging");
        };

        dropZone.ondragenter = showActive;
        dropZone.ondragover = showActive;
        dropZone.ondragleave = clearActive;
        dropZone.ondrop = (event) => {
            event.preventDefault();
            event.stopPropagation();
            dropZone.classList.remove("is-dragging");

            const files = event.dataTransfer?.files;
            if (!files || files.length === 0) return;

            const transfer = new DataTransfer();
            for (const file of files) {
                transfer.items.add(file);
            }

            input.files = transfer.files;
            input.dispatchEvent(new Event("change", { bubbles: true }));
        };
    };

    const downloadBase64 = (fileName, base64Data, contentType) => {
        const binary = atob(base64Data);
        const bytes = new Uint8Array(binary.length);
        for (let i = 0; i < binary.length; i++) {
            bytes[i] = binary.charCodeAt(i);
        }

        const blob = new Blob([bytes], { type: contentType || "application/octet-stream" });
        const url = URL.createObjectURL(blob);
        const anchor = document.createElement("a");
        anchor.href = url;
        anchor.download = fileName;
        anchor.style.display = "none";
        document.body.appendChild(anchor);
        anchor.click();
        anchor.remove();
        setTimeout(() => URL.revokeObjectURL(url), 1000);
    };

    const scrollTo = (elementId) => {
        document.getElementById(elementId)?.scrollIntoView({ behavior: "smooth", block: "start" });
    };

    const scrollToTop = () => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    };

    const initToTop = (threshold = 240) => {
        const setup = () => {
            const btn = document.getElementById('toTop');
            if (!btn) return;

            const onScroll = () => {
                if (window.scrollY > threshold) btn.classList.add('show');
                else btn.classList.remove('show');
            };

            window.addEventListener('scroll', onScroll, { passive: true });
            // ensure button triggers smooth scroll even if onclick attribute is absent
            btn.addEventListener('click', scrollToTop);
            onScroll();
        };

        if (document.readyState === 'loading') {
            document.addEventListener('DOMContentLoaded', setup);
        } else {
            setup();
        }
    };

    return {
        initializeDragDrop,
        downloadBase64,
        scrollTo,
        scrollToTop,
        initToTop
    };
})();

// Auto-initialize the to-top watcher if possible
(function(){
    try { if (window.projectRadar && typeof window.projectRadar.initToTop === 'function') window.projectRadar.initToTop(); } catch(e){}
})();
